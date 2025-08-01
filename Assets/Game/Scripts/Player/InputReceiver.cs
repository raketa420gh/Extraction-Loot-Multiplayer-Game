using System;
using Fusion;
using UnityEngine;

public class InputReceiver : NetworkBehaviour
{
    public event Action<Vector3, float> OnMove;
    public event Action OnFire;

    [Networked]
    private NetworkButtons _previousButtons { get; set; }

    public override void FixedUpdateNetwork()
    {
        float deltaTime = Runner.DeltaTime;

        if (GetInput(out InputData input))
        {
            ProcessMove(input, deltaTime);
            ProcessFire(input);
        }

        _previousButtons = input.Buttons;
    }

    private void ProcessMove(InputData input, float deltaTime)
    {
        Vector3 moveDirection = input.Direction;
        if (moveDirection != Vector3.zero)
            OnMove?.Invoke(moveDirection, deltaTime);
    }

    private void ProcessFire(InputData input)
    {
        if (input.Buttons.WasPressed(_previousButtons, InputKeys.Fire) && Runner.IsForward)
        {
            OnFire?.Invoke();
        }
    }
}
