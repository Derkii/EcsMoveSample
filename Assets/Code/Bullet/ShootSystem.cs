using Code.Ecs;
using Code.EcsFactory;
using Code.GeneralEcsComponents;
using Code.Input;
using Code.Movement;
using Code.Requests;
using Code.Timer;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bullet
{
    public class ShootSystem : IEcsRunSystem, IEcsInitSystem
    {
        private BulletFactory _bulletFactory;
        private float _lifeTime;
        private float _fireDelay;
        private float _bulletSpeed;
        private EcsPackedEntity _shootTimerEntity;

        public ShootSystem(BulletFactory bulletFactory, float lifeTime, float bulletSpeed, float fireDelay)
        {
            _bulletFactory = bulletFactory;
            _lifeTime = lifeTime;
            _bulletSpeed = bulletSpeed;
            _fireDelay = fireDelay;
        }

        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var shootRequestFilter = ecsWorld.Filter<ShootRequestSelf>().End();

            ref var timerComponent = ref _shootTimerEntity.Get<TimerComponent>(ecsWorld);

            foreach (var entity in shootRequestFilter)
            {
                entity.Del<ShootRequestSelf>(ecsWorld);
                if (timerComponent.Time > 0f) return;
                timerComponent.Time =
                    timerComponent.StartTime;
                var instance = _bulletFactory.Spawn(out int bulletEntity, ecsWorld);
                instance.transform.position = entity.Get<UnityRef<GameObject>>(ecsWorld).Value.transform.position;
                ref var factoryComponent = ref bulletEntity.Get<FactoryComponent>(ecsWorld);
                factoryComponent.Factory = _bulletFactory;
                ref var bulletTimerComponent = ref bulletEntity.Get<TimerComponent>(ecsWorld);
                bulletTimerComponent.StartTime = bulletTimerComponent.Time = _lifeTime;
                bulletEntity.Get<InputComponent>(ecsWorld).Direction =
                    entity.Get<UnityRef<GameObject>>(ecsWorld).Value.transform.forward;
                bulletEntity.Get<MovementSpeed>(ecsWorld).Speed = _bulletSpeed;
            }
        }

        public void Init(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var entity = ecsWorld.NewEntity();
            ref var timerComponent = ref entity.Add<TimerComponent>(ecsWorld);
            timerComponent.StartTime = timerComponent.Time = _fireDelay;
            _shootTimerEntity = ecsWorld.PackEntity(entity);
        }
    }
}