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
        private PlayerMono _playerPrefab;
        private float _movementSpeed;
        private Transform _spawnPoint;

        public PlayerSpawnSystem(PlayerMono playerPrefab, float movementSpeed, Transform spawnPoint)
        {
            _movementSpeed = movementSpeed;
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
        }

        public void Init(IEcsSystems systems)
        {
            var playerInstance = GameObject.Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);
            var ecsWorld = systems.GetWorld();
            var entity = ecsWorld.NewEntity();

            var cameraTransform = Camera.main.transform;

            cameraTransform.SetParent(playerInstance.CameraParent);
            cameraTransform.localRotation = Quaternion.Euler(Vector3.zero);
            cameraTransform.localPosition = Vector3.zero;

            entity.Add<UnityRef<Rigidbody>>(ecsWorld).Value = playerInstance.GetComponent<Rigidbody>();
            entity.Add<InputComponent>(ecsWorld);
            entity.Add<PlayerTag>(ecsWorld);
            entity.Add<MovementSpeed>(ecsWorld).Speed = _movementSpeed;
            entity.Add<SpawnPointComponent>(ecsWorld).SpawnPoint = _spawnPoint;
            entity.Add<UnityRef<GameObject>>(ecsWorld).Value = playerInstance.gameObject;
            entity.Add<GroundDetectComponent>(ecsWorld).Origin = playerInstance.transform;
        }
    }
}