public static class RoundManager
{
    
    private static Round.RoundController roundController;


    public static void SetRoundController(Round.RoundController controller)
    {
        roundController = controller;
    }

    public static void StartRound(int curRound)
    {
        roundController.StartRound(curRound);
    }
}
