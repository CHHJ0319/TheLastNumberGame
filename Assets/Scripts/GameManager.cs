using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene")
        {
            StartGameSecne();
        }
    }

    private void StartGameSecne()
    {
        RoundManager.StartRound();
    }

    
}
