using Code.Ecs;
using Code.Requests;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Player
{
    public class PlayerShootInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsPackedEntity _player;
        private KeyCode _shootKeyCode;

        public PlayerShootInputSystem(KeyCode keyCode)
        {
            _shootKeyCode = keyCode;
        }


        public void Run(IEcsSystems systems)
        {
            if (UnityEngine.Input.GetKeyDown(_shootKeyCode))
            {
                _player.Add<ShootRequestSelf>(systems.GetWorld());
            }
        }

        public void Init(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            _player = ecsWorld.PackEntity((int)ecsWorld.Filter<PlayerTag>().End().GetRawEntities().GetValue(0));
        }
    }
}