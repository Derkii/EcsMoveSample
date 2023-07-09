using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Ecs
{
    public abstract class EcsSystemGroupAdd : MonoBehaviour
    {
        public abstract void AddSystems(IEcsSystems updateSystems, IEcsSystems fixedUpdateSystems);
    }
}