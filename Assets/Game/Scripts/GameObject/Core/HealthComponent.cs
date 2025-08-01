using Fusion;
using UnityEngine;

public sealed class HealthComponent : NetworkBehaviour
{
    [Networked]
    public int Health { get; private set; }

    public bool TakeDamage(int damage)
    {
        if (Health == 0)
            return false;
        
        Health = Mathf.Max(0, Health - damage);
        return true;
    }

    public bool Exists()
    {
        return Health > 0;
    }
}