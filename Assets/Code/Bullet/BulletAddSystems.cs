using Code.Ecs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletAddSystems : EcsSystemGroupAdd
    {
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private float _bulletLifeTime, _bulletSpeed, _bulletFireDelay;

        public override void AddSystems(IEcsSystems updateSystems, IEcsSystems fixedUpdateSystems)
        {
            updateSystems.Add(new ShootSystem(_bulletFactory, _bulletLifeTime, _bulletSpeed, _bulletFireDelay));
            updateSystems.Add(new BulletLifeTimeSystem());
        }
    }
}