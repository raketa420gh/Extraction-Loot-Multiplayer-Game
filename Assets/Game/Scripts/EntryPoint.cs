using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public sealed class EntryPoint : MonoBehaviour
{
    [SerializeField] 
    private NetworkRunner _networkRunner;
    
    [SerializeField]
    private NetworkSceneManagerDefault _networkSceneManager;
    
    private void Start()
    {
        _networkRunner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.AutoHostOrClient,
            SessionName = "SampleSession",
            Scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex),
            SceneManager = _networkSceneManager
        });
    }
}