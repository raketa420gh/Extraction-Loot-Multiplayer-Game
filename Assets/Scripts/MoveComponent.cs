using UnityEngine;

public sealed class MoveComponent : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5;

    public void MoveStep(Vector3 step)
    {
        transform.position += step * _speed;
    }
}