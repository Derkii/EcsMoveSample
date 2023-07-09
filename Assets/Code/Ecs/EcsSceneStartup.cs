using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Ecs
{
    public class EcsSceneStartup : MonoBehaviour
    {
        [SerializeField] private EcsSystemGroupAdd[] _systemGroupAdds;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        private EcsWorld _world;
        public EcsWorld World => _world;

        private void Awake()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            var injectableSystemAdds = new List<IInjectable>();
            foreach (var systemAdd in _systemGroupAdds)
            {
                systemAdd.AddSystems(_updateSystems, _fixedUpdateSystems);
                if (systemAdd is IInjectable injectable)
                {
                    injectableSystemAdds.Add(injectable);
                }
            }

            foreach (var injectableSystemAdd in injectableSystemAdds)
            {
                injectableSystemAdd.Inject(_updateSystems);
                injectableSystemAdd.Inject(_fixedUpdateSystems);
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