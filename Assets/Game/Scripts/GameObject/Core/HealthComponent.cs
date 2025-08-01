using System;
using Fusion;
using UnityEngine;

public sealed class HealthComponent : NetworkBehaviour
{
    public event Action<int> OnHealthChanged;

    [Networked]
    [OnChangedRender(nameof(InvokeHealthChanged))]
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

    private void InvokeHealthChanged()
    {
        OnHealthChanged?.Invoke(Health);
    }
}