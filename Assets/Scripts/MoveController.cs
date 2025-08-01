using Fusion;
using UnityEngine;

public sealed class MoveController: NetworkBehaviour
{
    [SerializeField]
    private MoveComponent _moveComponent;

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputData data))
            _moveComponent.MoveStep(data.Direction * Runner.DeltaTime);
    }
}