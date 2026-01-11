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
        ActorManager.Initialize();

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene")
        {
            StartGameSecne();
        }
        else if (currentScene.name == "IntroScene")
        {
            StartIntroSecne();
        }
        else if (currentScene.name == "EndingScene")
        {
            StartEndingSecne();
        }
    }

    private void StartIntroSecne()
    {
        UIManager.SetIntroSceneDialogText(0);
    }

    private void StartGameSecne()
    {
        ActorManager.GenerateEnemyProfile();
        RoundManager.StartRound();
    }

    private void StartEndingSecne()
    {
        UIManager.SetEndingScene();
    }
}
