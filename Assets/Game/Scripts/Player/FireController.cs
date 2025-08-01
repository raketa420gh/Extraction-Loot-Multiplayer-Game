using UnityEngine;

public sealed class FireController : MonoBehaviour
{
    [SerializeField]
    private InputReceiver _inputReceiver;
    
    [SerializeField]
    private FireComponent _fireComponent;

    private void OnEnable()
    {
        _inputReceiver.OnFire += _fireComponent.Fire;
    }

    private void OnDisable()
    {
        _inputReceiver.OnFire -= _fireComponent.Fire;
    }
}