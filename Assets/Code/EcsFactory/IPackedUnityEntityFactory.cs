using Leopotam.EcsLite;
using UnityEngine;

namespace Code.EcsFactory
{
    public interface IPackedUnityEntityFactory
    {
        public GameObject Spawn(out EcsPackedEntity entity, EcsWorld world);

        public void Despawn(GameObject gameObject, EcsPackedEntity entity, EcsWorld world);
    }
}