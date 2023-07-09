using Ecs;
using GeneralEcsComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Movement
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<Input.InputComponent, MonoRef<Rigidbody>, MovementSpeed> _filter;
        
        public void Run()
        {
            foreach (var enemyIndex in _filter)
            {
                ref var input = ref _filter.Get1(enemyIndex);
                ref var rigidbody = ref _filter.Get2(enemyIndex);
                ref var movementSpeed = ref _filter.Get3(enemyIndex);
                
                rigidbody.Mono.velocity = new Vector3(input.Direction.x, rigidbody.Mono.velocity.y, input.Direction.z) * movementSpeed.Speed;
            }
        }
    }
}