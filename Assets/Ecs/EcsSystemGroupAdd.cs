using Leopotam.Ecs;
using UnityEngine;

namespace Ecs
{
    public abstract class EcsSystemGroupAdd : MonoBehaviour
    {
        public abstract void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems);
    }
}