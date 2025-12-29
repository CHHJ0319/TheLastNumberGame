using Round;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int totalRound = 10;
    void Awake()
    {
        RoundManager.Initialize();
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            RoundManager.StartRound(i + 1);
        }

        for (int i = 3; i < 6; i++)
        {
            RoundManager.StartRound(i + 1);
        }

        for (int i = 6; i < 9; i++)
        {
            RoundManager.StartRound(i + 1);
        }

        RoundManager.StartRound(10);
    }
}
