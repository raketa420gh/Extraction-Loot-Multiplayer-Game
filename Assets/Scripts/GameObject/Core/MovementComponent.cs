using System;
using UnityEngine;

public sealed class MovementComponent : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5;

    private Func<bool> _condition;

    public void SetCondition(Func<bool> condition)
    {
        _condition = condition;
    }

    public bool CanMove()
    {
        return _condition == null || _condition.Invoke();
    }

    public void MoveStep(Vector3 direction, float deltaTime)
    {
        if (CanMove())
            transform.position += direction * (_speed * deltaTime);
    }
}