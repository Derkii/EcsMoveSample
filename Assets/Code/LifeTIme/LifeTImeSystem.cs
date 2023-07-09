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
            foreach (var entityIndex in filter)
            {
                ref var lifeTime = ref entityIndex.Get<LifeTime>(systems.GetWorld());
                if (lifeTime.Time <= 0f)
                {
                    entityIndex.Get<FactoryComponent>(filter.GetWorld()).Factory.Despawn(
                        entityIndex.Get<UnityRef<GameObject>>(systems.GetWorld()).Value, entityIndex,
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