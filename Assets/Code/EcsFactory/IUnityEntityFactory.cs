using Leopotam.EcsLite;
using UnityEngine;

namespace Code.EcsFactory
{
    public interface IUnityEntityFactory
    {
        public GameObject Spawn(out int entity, EcsWorld world);

        public void Despawn(GameObject gameObject, int entity, EcsWorld world);
    }
}