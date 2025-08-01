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
        var buttons = new NetworkButtons();
        AccumulateFire(ref buttons);
        
        input.Set(new InputData
        {
            Direction = AccumulateMove(),
            Buttons = buttons
        });
    }

    private void AccumulateFire(ref NetworkButtons buttons)
    {
        buttons.Set(InputKeys.Fire, Input.GetMouseButton(0));
    }

    private Vector3 AccumulateMove()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        
        return new Vector3(dx, 0, dz);
    }
}