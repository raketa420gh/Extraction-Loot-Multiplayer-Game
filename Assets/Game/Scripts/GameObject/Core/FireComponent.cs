using Fusion;
using UnityEngine;

public sealed class FireComponent : NetworkBehaviour
{
    [SerializeField] 
    private Transform _firePoint;
    
    [SerializeField]
    private NetworkPrefabRef _projectilePrefab;
    
    public void Fire()
    {
        if (!Runner.IsServer)
            return;
        
        PlayerRef player = Object.InputAuthority;
        Vector3 position = _firePoint.position;
        Quaternion rotation = _firePoint.rotation;
        Runner.Spawn(_projectilePrefab, position, rotation, player);
    }
}