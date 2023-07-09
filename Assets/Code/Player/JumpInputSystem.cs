using Code.Ecs;
using Code.Requests;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Player
{
    public class JumpInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsPackedEntity _player;
        private KeyCode _jumpKeyCode;

        public JumpInputSystem(KeyCode jumpKeyCode)
        {
            _jumpKeyCode = jumpKeyCode;
        }

        public void Run(EcsSystems systems)
        {
            if (UnityEngine.Input.GetKeyDown(_jumpKeyCode))
            {
                var ecsWorld = systems.GetWorld();
                if (_player.Unpack(ecsWorld, out int entityIndex))
                {
                    entityIndex.Add<JumpRequestSelf>(ecsWorld);
                    entityIndex.Add<GroundDetectRequestSelf>(ecsWorld);
                }
            }
        }

        public void Init(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            _player = ecsWorld.PackEntity((int)ecsWorld.Filter<PlayerTag>().End().GetRawEntities().GetValue(0));
        }
    }
}