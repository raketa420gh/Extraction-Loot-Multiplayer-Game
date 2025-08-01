using Fusion;
using UnityEngine;

public sealed class PlayerLeftController : MonoBehaviour
{
    [SerializeField] 
    private NetworkEvents _networkEvents;

    private void OnEnable()
    {
        _networkEvents.PlayerLeft.AddListener(OnPlayerLeft);
    }

    private void OnDisable()
    {
        _networkEvents.PlayerLeft.RemoveListener(OnPlayerLeft);
    }

    private void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            NetworkObject character = runner.GetPlayerObject(player);
            runner.Despawn(character);
        }
    }
}