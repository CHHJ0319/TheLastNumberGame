using Round;


public static class RoundManager
{
    
    private static Round.RoundController roundController;


    public static void SetRoundController(RoundController controller)
    {
        roundController = controller;
    }

    public static void StartRound(int curRound)
    {
        roundController.Initialize();
        roundController.StartRound(curRound);
    }

    //public static void FinishPlayerTurn()
    //{
    //    roundController.FinishPlayerTurn();
    //}
}
