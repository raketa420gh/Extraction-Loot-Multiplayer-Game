using Fusion;
using UnityEngine;

public sealed class PlayerJoinController : MonoBehaviour
{
    [SerializeField] 
    private NetworkEvents _networkEvents;
    
    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField] 
    private SpawnPointService _spawnPointService;

    private void OnEnable()
    {
        _networkEvents.PlayerJoined.AddListener(OnPlayerJoined);
    }

    private void OnDisable()
    {
        _networkEvents.PlayerJoined.RemoveListener(OnPlayerJoined);
    }

    private void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (!runner.IsServer)
            return;

        Transform spawnPoint = _spawnPointService.GetSpawnPoint(player);
        NetworkObject character = runner.Spawn(_playerPrefab, spawnPoint.position, spawnPoint.rotation, player);
        runner.SetPlayerObject(player, character);
    }
}