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
            foreach (var entity in filter)
            {
                var instance = _bulletFactory.Spawn(out int bulletEntity, ecsWorld);
                instance.transform.position = entity.Get<UnityRef<GameObject>>(ecsWorld).Value.transform.position;
                ref var factoryComponent = ref bulletEntity.Get<FactoryComponent>(ecsWorld);
                factoryComponent.Factory = _bulletFactory;
                bulletEntity.Get<LifeTime>(ecsWorld).Time = _lifeTime;
                bulletEntity.Get<InputComponent>(ecsWorld).Direction =
                    entity.Get<UnityRef<GameObject>>(ecsWorld).Value.transform.forward;
                bulletEntity.Get<MovementSpeed>(ecsWorld).Speed = _bulletSpeed;
                factoryComponent.PackedFactory = _bulletFactory;
                entity.Del<ShootRequestSelf>(ecsWorld);
            }
        }
    }
}