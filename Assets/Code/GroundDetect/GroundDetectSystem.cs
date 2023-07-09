using Code.Ecs;
using Code.Requests;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.GroundDetect
{
    public class GroundDetectSystem : IEcsRunSystem
    {
        private LayerMask _groundLayerMask;
        private float _maxDistanceForRay;

        public GroundDetectSystem(LayerMask groundLayerMask, float maxDistanceForRay)
        {
            _groundLayerMask = groundLayerMask;
            _maxDistanceForRay = maxDistanceForRay;
        }

        public void Run(EcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = ecsWorld.Filter<GroundDetectComponent>().Inc<GroundDetectRequestSelf>().End();

            foreach (var entity in filter)
            {
                ref var groundDetect = ref entity.Get<GroundDetectComponent>(ecsWorld);
                groundDetect.OnGround = Physics.Raycast(groundDetect.Origin.position, -groundDetect.Origin.up,
                    _maxDistanceForRay, _groundLayerMask);
                entity.Del<GroundDetectRequestSelf>(ecsWorld);
            }
        }
    }
}