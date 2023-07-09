using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    public class PlayerAddSystems : Ecs.EcsSystemGroupAdd
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _movementSpeed;
        public override void AddSystems(EcsSystems updateSystems, EcsSystems fixedUpdateSystems)
        {
            updateSystems.Add(new PlayerSpawnSystem(_playerPrefab, _movementSpeed, _spawnPoint));
            updateSystems.Add(new PlayerInputSystem());
        }
    }
}