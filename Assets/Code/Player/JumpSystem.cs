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

        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            _filter = ecsWorld.Filter<UnityRef<Rigidbody>>().Inc<JumpRequestSelf>().Inc<GroundDetectComponent>().End();
            foreach (var entityIndex in _filter)
            {
                entityIndex.Del<JumpRequestSelf>(ecsWorld);
                AddForce(entityIndex, ecsWorld);
            }
        }

        private async UniTaskVoid AddForce(int entityIndex, EcsWorld ecsWorld)
        {
            if (entityIndex.Get<GroundDetectComponent>(ecsWorld).OnGround == false) return;
            UniTask.WaitForFixedUpdate();

            var rigidbody = entityIndex.Get<UnityRef<Rigidbody>>(ecsWorld).Value;
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, _jumpForce, rigidbody.velocity.z);
        }
    }
}