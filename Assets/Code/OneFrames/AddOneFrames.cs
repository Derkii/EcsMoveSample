using Code.OneFramesSource;
using Leopotam.EcsLite;
using TNRD;
using UnityEngine;

namespace Code.OneFrames
{
    public class AddOneFrames : Ecs.EcsSystemGroupAdd
    {
        [SerializeField] private SerializableInterface<IOneFrame>[] _oneFrames;

        public override void AddSystems(IEcsSystems updateSystems, IEcsSystems fixedUpdateSystems)
        {
            foreach (var oneFrame in _oneFrames)
            {
                updateSystems.Add(new OneFrameSystem(oneFrame.Value.GetType()));
            }
        }
    }
}