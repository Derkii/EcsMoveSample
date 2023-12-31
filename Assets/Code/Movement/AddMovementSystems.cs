﻿using Leopotam.EcsLite;

namespace Code.Movement
{
    public class AddMovementSystems : Ecs.EcsSystemGroupAdd
    {
        public override void AddSystems(IEcsSystems updateSystems, IEcsSystems fixedUpdateSystems)
        {
            fixedUpdateSystems.Add(new MovementSystem());
        }
    }
}