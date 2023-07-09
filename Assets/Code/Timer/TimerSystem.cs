using Code.Ecs;
using Code.OneFrames;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Timer
{
    public class TimerSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<TimerComponent>().End();

            foreach (var entity in filter)
            {
                ref var timer = ref entity.Get<TimerComponent>(ecsWorld);
                if (timer.Time <= 0f)
                {
                    if (ecsWorld.GetPool<OnTimerOver>().Has(entity) == false)
                        entity.Add<OnTimerOver>(ecsWorld);
                }

                timer.Time -= Time.deltaTime;
            }
        }
    }
}