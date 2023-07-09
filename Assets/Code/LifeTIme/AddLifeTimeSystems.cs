using Leopotam.EcsLite;

namespace Code.LifeTIme
{
    public class AddLifeTimeSystems : Ecs.EcsSystemGroupAdd
    {
        public override void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems)
        {
            updateSystems.Add(new LifeTImeSystem());
        }
    }
}