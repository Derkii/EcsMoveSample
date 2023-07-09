using Leopotam.EcsLite;

namespace Code.Timer
{
    public class AddTimerSystems : Ecs.EcsSystemGroupAdd
    {
        public override void AddSystems(IEcsSystems updateSystems, IEcsSystems fixedUpdateSystems)
        {
            updateSystems.Add(new TimerSystem());
        }
    }
}