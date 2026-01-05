public static class RoundManager
{
    private static Round.RoundController roundController;

    private static int totalRound = 10;
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
        roundController.StartRound(currentRound);
        UIManager.SetGameScene(currentRound, roundWinResults);
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
}
