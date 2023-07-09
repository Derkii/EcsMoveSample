using Leopotam.EcsLite;
using UnityEngine;

namespace Code.GroundDetect
{
    public class AddGroundDetectSystems : Ecs.EcsSystemGroupAdd
    {
        [SerializeField] private float _maxDistanceForRay;
        [SerializeField] private LayerMask _groundLayerMask;

        public override void AddSystems(IEcsSystems updateSystems, IEcsSystems fixedUpdateSystems)
        {
            updateSystems.Add(new GroundDetectSystem(_groundLayerMask, _maxDistanceForRay));
        }
    }
}