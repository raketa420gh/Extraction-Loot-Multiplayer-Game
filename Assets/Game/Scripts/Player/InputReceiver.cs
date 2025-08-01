using System;
using Fusion;
using UnityEngine;

public class InputReceiver : NetworkBehaviour
{
    public event Action<Vector3, float> OnMove;

    public override void FixedUpdateNetwork()
    {
        float deltaTime = Runner.DeltaTime;

        if (GetInput(out InputData input))
        {
            ProcessMove(input, deltaTime);
        }
    }

    private void ProcessMove(InputData input, float deltaTime)
    {
        Vector3 moveDirection = input.Direction;
        if (moveDirection != Vector3.zero)
            OnMove?.Invoke(moveDirection, deltaTime);
    }
}
