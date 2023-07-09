using Code.Ecs;
using Code.Input;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Player
{
    public class PlayerMovementInputSystem : IEcsRunSystem
    {
        private EcsFilter _filter;

        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            _filter = ecsWorld.Filter<InputComponent>().Inc<PlayerTag>().End();
            foreach (var entityIndex in _filter)
            {
                ref var inputComponent = ref entityIndex.GetOrAdd<InputComponent>(ecsWorld);

                inputComponent.Direction = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f,
                    UnityEngine.Input.GetAxis("Vertical"));
            }
        }
    }
}