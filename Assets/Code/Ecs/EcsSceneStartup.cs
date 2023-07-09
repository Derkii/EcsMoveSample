using System;
using System.Linq;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Ecs
{
    public class EcsSceneStartup : MonoBehaviour
    {
        [SerializeField] private EcsSystemGroupAdd[] _systemGroupAdds;
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;
        private EcsWorld _world;

        private void Awake()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            foreach (var systemAdd in _systemGroupAdds)
            {
#if UNITY_EDITOR
                if (_systemGroupAdds.Count(t => t == systemAdd) > 1)
                    throw new Exception("Dublicate of add systems component");
#endif
                systemAdd.AddSystems(_updateSystems, _fixedUpdateSystems);
            }
        }

        private void Start()
        {
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems.Run();
        }
    }
}