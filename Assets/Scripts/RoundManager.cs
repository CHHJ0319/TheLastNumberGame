using System.Collections.Generic;

public static class RoundManager
{
    
    private static Round.RoundController roundController;
    
    public static void Initialize()
    {
        roundController = new Round.RoundController();
    }

    public static void StartRound(int curRound)
    {
        roundController.Initialize();
        roundController.StartRound(curRound);
    }
}
