using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    

    private void Start()
    {
        Events.RoundEvents.Clear();
        UIManager.Initailize();
        RoundManager.Initialize();

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene")
        {
            StartGameSecne();
        }
        else if (currentScene.name == "EndingScene")
        {
            StartEndingSecne();
        }
    }

    private void StartGameSecne()
    {
        RoundManager.StartRound();
    }

    private void StartEndingSecne()
    {
        UIManager.SetEndingScene();
    }
}
