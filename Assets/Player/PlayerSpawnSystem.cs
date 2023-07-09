using GeneralEcsComponents;
using Input;
using Leopotam.Ecs;
using Movement;
using UnityEngine;

namespace Player
{
    public class PlayerSpawnSystem : IEcsInitSystem
    {
        private GameObject _playerPrefab;
        private float _movementSpeed;
        private Transform _spawnPoint;
        private EcsWorld _ecsWorld;

        public PlayerSpawnSystem(GameObject playerPrefab, float movementSpeed, Transform spawnPoint)
        {
            _movementSpeed = movementSpeed;
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
        }

        public void Init()
        {
            var playerInstance = GameObject.Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);
            var entity = _ecsWorld.NewEntity();
            
            entity.Get<MonoRef<Rigidbody>>().Mono = playerInstance.GetComponent<Rigidbody>();
            entity.Get<InputComponent>();
            entity.Get<PlayerTag>();
            entity.Get<MovementSpeed>().Speed = _movementSpeed;
            entity.Get<SpawnPointComponent>().SpawnPoint = _spawnPoint;
        }
    }
}