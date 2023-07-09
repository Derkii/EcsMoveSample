using Code.Ecs;
using Code.EcsFactory;
using Code.GeneralEcsComponents;
using Code.Input;
using Code.Movement;
using Code.Timer;
using Leopotam.EcsLite;
using Plugins.NightPool.Code.NightPool;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletFactory : MonoBehaviour, IUnityEntityFactory
    {
        [SerializeField] private GameObject _prefab;
        private float _bulletMovementSpeed;

        public GameObject Spawn(out int entity, EcsWorld world)
        {
            var instance = NightPool.Spawn(_prefab);
            entity = world.NewEntity();

            entity.Add<UnityRef<Rigidbody>>(world).Value = instance.GetComponent<Rigidbody>();
            entity.Add<InputComponent>(world);
            entity.Add<BulletTag>(world);
            entity.Add<TimerComponent>(world);
            entity.Add<UnityRef<GameObject>>(world).Value = instance;
            entity.Add<FactoryComponent>(world);
            entity.Add<MovementSpeed>(world);

            return instance;
        }

        public void Despawn(GameObject gameObject, int entity, EcsWorld world)
        {
            NightPool.Despawn(gameObject);
            world.DelEntity(entity);
        }
    }
}