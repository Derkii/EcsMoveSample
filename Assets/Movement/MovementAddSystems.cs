using Leopotam.Ecs;

namespace Movement
{
    public class MovementAddSystems : Ecs.EcsSystemGroupAdd
    {
        public override void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems)
        {
            fixedUpdateSystems.Add(new MovementSystem()); 
        }
    }
}