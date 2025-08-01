using UnityEngine;

public sealed class MoveController: MonoBehaviour
{
    [SerializeField]
    private InputReceiver _inputReceiver;
    
    [SerializeField]
    private MovementComponent _movementComponent;
    
    [SerializeField]
    private RotationComponent _rotationComponent;

    private void OnEnable()
    {
        _inputReceiver.OnMove += OnMove;
    }

    private void OnDisable()
    {
        _inputReceiver.OnMove -= OnMove;
    }

    private void OnMove(Vector3 direction, float deltaTime)
    {
        _movementComponent.MoveStep(direction, deltaTime);
        _rotationComponent.RotateStep(direction, deltaTime);
    }
}