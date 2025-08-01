using System;
using Fusion;
using UnityEngine;

public sealed class SpawnPointService : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint1;
    
    [SerializeField]
    private Transform _spawnPoint2;

    public Transform GetSpawnPoint(PlayerRef player)
    {
        return player.PlayerId == 1 ? _spawnPoint1 : _spawnPoint2;
    }
}