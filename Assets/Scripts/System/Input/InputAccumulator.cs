using Fusion;
using UnityEngine;

public sealed class InputAccumulator : MonoBehaviour
{
    [SerializeField]
    private NetworkEvents _networkEvents;

    private void OnEnable()
    {
        _networkEvents.OnInput.AddListener(OnInput);
    }

    private void OnDisable()
    {
        _networkEvents.OnInput.RemoveListener(OnInput);
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        input.Set(new InputData
        {
            Direction = new Vector3(dx, 0, dz),
        });
    }
}