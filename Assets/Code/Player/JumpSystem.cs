using Code.Ecs;
using Code.GeneralEcsComponents;
using Code.GroundDetect;
using Code.Requests;
using Cysharp.Threading.Tasks;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Player
{
    public class JumpSystem : IEcsRunSystem
    {
        private float _jumpForce;
        private EcsFilter _filter;

        public JumpSystem(float jumpForce)
        {
            _jumpForce = jumpForce;
        }

        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            _filter = ecsWorld.Filter<UnityRef<Rigidbody>>().Inc<JumpRequestSelf>().Inc<GroundDetectComponent>().End();
            foreach (var entity in _filter)
            {
                entity.Del<JumpRequestSelf>(ecsWorld);
                AddForce(entity, ecsWorld);
            }
        }

        private async UniTaskVoid AddForce(int entity, EcsWorld ecsWorld)
        {
            if (entity.Get<GroundDetectComponent>(ecsWorld).OnGround == false) return;
            UniTask.WaitForFixedUpdate();

            var rigidbody = entity.Get<UnityRef<Rigidbody>>(ecsWorld).Value;
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, _jumpForce, rigidbody.velocity.z);
        }
    }
}