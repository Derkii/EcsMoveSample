using Code.Ecs;
using Code.GeneralEcsComponents;
using Code.Input;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Movement
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter _filter;

        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            _filter = ecsWorld.Filter<InputComponent>().Inc<UnityRef<Rigidbody>>().Inc<MovementSpeed>().End();
            foreach (var entityIndex in _filter)
            {
                ref var input = ref entityIndex.GetOrAdd<InputComponent>(ecsWorld);
                ref var rigidbody = ref entityIndex.GetOrAdd<UnityRef<Rigidbody>>(ecsWorld);
                ref var movementSpeed = ref entityIndex.GetOrAdd<MovementSpeed>(ecsWorld);

                rigidbody.Value.velocity = new Vector3(input.Direction.x * movementSpeed.Speed,
                    rigidbody.Value.velocity.y, input.Direction.z * movementSpeed.Speed);
            }
        }
    }
}