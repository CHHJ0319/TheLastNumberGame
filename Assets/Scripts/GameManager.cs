using Round;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static int totalRound = 10;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        GameObject go = new GameObject("GameManager");
        Instance = go.AddComponent<GameManager>();
        DontDestroyOnLoad(go);
    }

    void Awake()
    {
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "GameScene")
        {
            StartMainSecne();
        }
    }

    private void StartMainSecne()
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    RoundManager.StartRound(i + 1);
        //}

        //for (int i = 3; i < 6; i++)
        //{
        //    RoundManager.StartRound(i + 1);
        //}

        //for (int i = 6; i < 9; i++)
        //{
        //    RoundManager.StartRound(i + 1);
        //}
        RoundManager.StartRound(10);
    }
}
