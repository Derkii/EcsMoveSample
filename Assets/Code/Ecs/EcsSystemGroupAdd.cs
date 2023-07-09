using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Ecs
{
    public abstract class EcsSystemGroupAdd : MonoBehaviour
    {
        public abstract void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems);
    }
}