using Code.Ecs;
using Code.GeneralEcsComponents;
using Code.GroundDetect;
using Code.Input;
using Code.Movement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Player
{
    public class PlayerSpawnSystem : IEcsInitSystem
    {
        private GameObject _playerPrefab;
        private float _movementSpeed;
        private Transform _spawnPoint;

        public PlayerSpawnSystem(GameObject playerPrefab, float movementSpeed, Transform spawnPoint)
        {
            _movementSpeed = movementSpeed;
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
        }

        public void Init(EcsSystems systems)
        {
            var playerInstance = GameObject.Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);
            var ecsWorld = systems.GetWorld();
            var entity = ecsWorld.NewEntity();

            entity.Add<UnityRef<Rigidbody>>(ecsWorld).Value = playerInstance.GetComponent<Rigidbody>();
            entity.Add<InputComponent>(ecsWorld);
            entity.Add<PlayerTag>(ecsWorld);
            entity.Add<MovementSpeed>(ecsWorld).Speed = _movementSpeed;
            entity.Add<SpawnPointComponent>(ecsWorld).SpawnPoint = _spawnPoint;
            entity.Add<UnityRef<GameObject>>(ecsWorld).Value = playerInstance;
            entity.Add<GroundDetectComponent>(ecsWorld).Origin = playerInstance.transform;
        }
    }
}