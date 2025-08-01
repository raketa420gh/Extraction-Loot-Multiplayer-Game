using Fusion;
using UnityEngine;

public sealed class CharacterView : NetworkBehaviour
{
    [SerializeField] 
    private GameObject _visual;
    
    [SerializeField]
    private HealthComponent _healthComponent;

    public override void Spawned()
    {
        _healthComponent.OnHealthChanged += OnHealthChanged;
        OnHealthChanged(_healthComponent.Health);
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        _healthComponent.OnHealthChanged -= OnHealthChanged;
    }

    public override void Render()
    {
        _visual.SetActive(_healthComponent.Exists());
    }

    private void OnHealthChanged(int health)
    {
        _visual.SetActive(health > 0);
    }
}