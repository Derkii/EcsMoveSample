using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Player
{
    public class AddPlayerSystems : Ecs.EcsSystemGroupAdd
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private KeyCode _jumpKeyCode, _shootKeyCode;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _movementSpeed;

        public override void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems)
        {
            updateSystems.Add(new PlayerSpawnSystem(_playerPrefab, _movementSpeed, _spawnPoint));
            updateSystems.Add(new PlayerMovementInputSystem());
            updateSystems.Add(new JumpInputSystem(_jumpKeyCode));
            fixedUpdateSystems.Add(new JumpSystem(_jumpForce));
            updateSystems.Add(new PlayerShootInputSystem(_shootKeyCode));
        }
    }
}