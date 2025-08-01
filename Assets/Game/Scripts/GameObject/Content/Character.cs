using Fusion;
using UnityEngine;

public sealed class Character : NetworkBehaviour
{
    [SerializeField]
    private HealthComponent _healthComponent;
    
    [SerializeField]
    private MovementComponent _movementComponent;
    
    [SerializeField]
    private RotationComponent _rotationComponent;

    public override void Spawned()
    {
        _movementComponent.SetCondition(_healthComponent.Exists);
        _rotationComponent.SetCondition(_healthComponent.Exists);
    }
}
