using System;
using Leopotam.EcsLite;

namespace Code.OneFramesSource
{
    public class OneFrameSystem
    {
        private Type _type;

        public OneFrameSystem(Type type)
        {
            _type = type;
        }

        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
        }
    }
}