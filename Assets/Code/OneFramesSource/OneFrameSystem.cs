using System;
using Leopotam.EcsLite;

namespace Code.OneFramesSource
{
    public class OneFrameSystem : IEcsRunSystem
    {
        private Type _type;

        public OneFrameSystem(Type type)
        {
            _type = type;
        }

        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            var filter = systems.GetWorld().Filter(_type).End();
            foreach (var entity in filter)
            {
                ecsWorld.GetPoolByType(_type).Del(entity);
            }
        }
    }
}