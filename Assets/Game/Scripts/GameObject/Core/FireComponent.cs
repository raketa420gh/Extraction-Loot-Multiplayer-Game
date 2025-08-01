using Fusion;
using UnityEngine;

public sealed class FireComponent : NetworkBehaviour
{
    [SerializeField] 
    private Transform _firePoint;
    
    [SerializeField]
    private NetworkPrefabRef _projectilePrefab;
    
    [SerializeField]
    private float _cooldown = 1;

    [Networked]
    private TickTimer _timer { get; set; }
    
    public void Fire()
    {
        if (!Runner.IsServer)
            return;

        if (!_timer.ExpiredOrNotRunning(Runner))
            return;
        
        PlayerRef player = Object.InputAuthority;
        Vector3 position = _firePoint.position;
        Quaternion rotation = _firePoint.rotation;
        Runner.Spawn(_projectilePrefab, position, rotation, player);

        _timer = TickTimer.CreateFromSeconds(Runner, _cooldown);
    }
}