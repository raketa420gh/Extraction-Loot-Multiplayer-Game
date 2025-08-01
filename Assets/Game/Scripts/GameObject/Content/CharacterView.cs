using Fusion;
using UnityEngine;

public sealed class CharacterView : NetworkBehaviour
{
    [SerializeField] 
    private GameObject _visual;
    
    [SerializeField]
    private HealthComponent _healthComponent;

    public override void Render()
    {
        _visual.SetActive(_healthComponent.Exists());
    }
}