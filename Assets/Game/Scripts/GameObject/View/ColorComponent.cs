using Fusion;
using UnityEngine;

public class ColorComponent : NetworkBehaviour
{
    [SerializeField]
    private Renderer _renderer;

    [SerializeField] 
    private Material _blue;
    
    [SerializeField]
    private Material _red;

    public override void Spawned()
    {
        Material material = HasInputAuthority ? _blue : _red;
        _renderer.material = material;
    }
}
