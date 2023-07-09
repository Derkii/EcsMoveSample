using Code.Ecs;
using Code.EcsFactory;
using Code.GeneralEcsComponents;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.LifeTIme
{
    public class LifeTImeSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld().Filter<FactoryComponent>().Inc<LifeTime>().End();
            foreach (var entity in filter)
            {
                ref var lifeTime = ref entity.Get<LifeTime>(systems.GetWorld());
                if (lifeTime.Time <= 0f)
                {
                    entity.Get<FactoryComponent>(filter.GetWorld()).Factory.Despawn(
                        entity.Get<UnityRef<GameObject>>(systems.GetWorld()).Value, entity,
                        systems.GetWorld());
                }
                else
                {
                    lifeTime.Time -= Time.deltaTime;
                }
            }
        }
    }
}