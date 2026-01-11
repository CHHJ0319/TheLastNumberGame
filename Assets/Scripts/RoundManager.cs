public static class RoundManager
{
    private static Round.RoundController roundController;

    private static int totalRound = 4;
    private static int currentRound = 1;
    private static bool[] roundWinResults = new bool[totalRound];

    public static void Initialize()
    {
        Events.RoundEvents.OnRoundEnded += RecordRoundResult;
    }

    public static void SetRoundController(Round.RoundController controller)
    {
        roundController = controller;
    }

    public static void StartRound()
    {
        UIManager.SetGameScene(currentRound);
        UIManager.UpdateRoundDisplay(currentRound);
        UIManager.SetEnemySprite(currentRound);

        roundController.StartRound(currentRound);
    }

    public static int GetCurrentRound()
    {
        return currentRound;
    }

    private static void RecordRoundResult(int curRound, bool isPlayerWinner)
    {
        roundWinResults[curRound - 1] = isPlayerWinner;
        SetNextRound();
    }

    private static void SetNextRound()
    {
        currentRound++;
    }

    public static void ResetRoundData()
    {
        currentRound = 1;

        roundWinResults = new bool[totalRound];
    }

    public static bool IsLastRound()
    {
        return currentRound == totalRound + 1;
    }
}
