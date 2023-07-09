using Code.Ecs;
using Code.EcsFactory;
using Code.GeneralEcsComponents;
using Code.Input;
using Code.LifeTIme;
using Code.Movement;
using Code.Requests;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bullet
{
    public class ShootSystem : IEcsRunSystem
    {
        private BulletFactory _bulletFactory;
        private float _lifeTime;
        private float _bulletSpeed;

        public ShootSystem(BulletFactory bulletFactory, float lifeTime, float bulletSpeed)
        {
            _bulletFactory = bulletFactory;
            _lifeTime = lifeTime;
            _bulletSpeed = bulletSpeed;
        }

        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<ShootRequestSelf>().End();
            foreach (var entityIndex in filter)
            {
                var instance = _bulletFactory.Spawn(out EcsPackedEntity entity, ecsWorld);
                instance.transform.position = entityIndex.Get<UnityRef<GameObject>>(ecsWorld).Value.transform.position;
                ref var factoryComponent = ref entity.Get<FactoryComponent>(ecsWorld);
                factoryComponent.Factory = _bulletFactory;
                entity.Get<LifeTime>(ecsWorld).Time = _lifeTime;
                entity.Get<InputComponent>(ecsWorld).Direction =
                    entityIndex.Get<UnityRef<GameObject>>(ecsWorld).Value.transform.forward;
                entity.Get<MovementSpeed>(ecsWorld).Speed = _bulletSpeed;
                factoryComponent.PackedFactory = _bulletFactory;
                entityIndex.Del<ShootRequestSelf>(ecsWorld);
            }
        }
    }
}