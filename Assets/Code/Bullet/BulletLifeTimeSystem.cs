using Code.Ecs;
using Code.EcsFactory;
using Code.GeneralEcsComponents;
using Code.OneFrames;
using Code.Timer;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletLifeTimeSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<TimerComponent>().Inc<OnTimerOver>().Inc<FactoryComponent>().Inc<BulletTag>()
                .Inc<UnityRef<GameObject>>().End();
            foreach (var entity in filter)
            {
                entity.Get<FactoryComponent>(ecsWorld).Factory.Despawn(entity.Get<UnityRef<GameObject>>(ecsWorld).Value,
                    entity, ecsWorld);
            }
        }
    }
}