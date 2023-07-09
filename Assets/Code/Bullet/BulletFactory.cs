using Code.Ecs;
using Code.EcsFactory;
using Code.GeneralEcsComponents;
using Code.Input;
using Code.LifeTIme;
using Code.Movement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletFactory : MonoBehaviour, IPackedUnityEntityFactory, IUnityEntityFactory
    {
        private float _bulletMovementSpeed;
        [SerializeField] private GameObject _prefab;

        public GameObject Spawn(out EcsPackedEntity entity, EcsWorld world)
        {
            var instance = Spawn(out int indexEntity, world);
            entity = world.PackEntity(indexEntity);
            return instance;
        }

        public void Despawn(GameObject gameObject, EcsPackedEntity entity, EcsWorld world)
        {
            entity.Unpack(world, out int index);
            Despawn(gameObject, index, world);
        }

        public GameObject Spawn(out int entity, EcsWorld world)
        {
            var instance = Instantiate(_prefab);
            entity = world.NewEntity();

            entity.Add<UnityRef<Rigidbody>>(world).Value = instance.GetComponent<Rigidbody>();
            entity.Add<InputComponent>(world);
            entity.Add<BulletTag>(world);
            entity.Add<LifeTime>(world);
            entity.Add<UnityRef<GameObject>>(world).Value = instance;
            entity.Add<FactoryComponent>(world);
            entity.Add<MovementSpeed>(world);

            return instance;
        }

        public void Despawn(GameObject gameObject, int entity, EcsWorld world)
        {
            Destroy(gameObject);
            world.DelEntity(entity);
        }
    }
}