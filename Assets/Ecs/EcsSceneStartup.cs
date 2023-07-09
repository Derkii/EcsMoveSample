using System.Collections.Generic;
using Ecs;
using UnityEngine;
using Leopotam.Ecs;

public class EcsSceneStartup : MonoBehaviour
{
    [SerializeField] private EcsSystemGroupAdd[] _systemGroupAdds;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems;

    private void Awake()
    {
        var world = new EcsWorld();
        _updateSystems = new EcsSystems(world);
        _fixedUpdateSystems = new EcsSystems(world);
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

