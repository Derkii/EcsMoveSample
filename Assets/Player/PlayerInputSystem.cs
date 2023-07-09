using Input;
using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent, PlayerTag> _filter;
        
        public void Run()
        {
            foreach (var enemyIndex in _filter)
            {
                ref var inputComponent = ref _filter.Get1(enemyIndex);

                inputComponent.Direction = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));
            }
        }
    }
}