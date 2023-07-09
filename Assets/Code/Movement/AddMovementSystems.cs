using Leopotam.EcsLite;

namespace Code.Movement
{
    public class AddMovementSystems : Ecs.EcsSystemGroupAdd
    {
        public override void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems)
        {
            fixedUpdateSystems.Add(new MovementSystem());
        }
    }
}