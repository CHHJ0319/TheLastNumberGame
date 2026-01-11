using System.Collections.Generic;
using UI;

public static class UIManager
{
    private static UIController uiController;
    private static bool _isPlayerWinner = true;

    public static void Initailize()
    {
        Events.RoundEvents.OnRoundEnded += SetIsPlayerWinner;
    }

    public static void SetUIController(UIController controller)
    {
        uiController = controller;
    }

    public static void UpdateRoundDisplay(int round)
    {
        uiController.UpdateRoundDisplay(round);
    }

    public static void UpdateTargetNumDisplay(int number)
    {
        uiController.UpdateTargetNumDisplay(number);
    }

    public static void SetGameScene(int curRound)
    {
        if (uiController != null)
        {
            uiController.SetRoundCounters(curRound);
        }
    }

    public static void SetEndingScene()
    {
        if (uiController != null)
        {
            uiController.SetEndingSceneUI(_isPlayerWinner);
        }
    }

    public static bool CanSubmit()
    {
        return uiController.CanSubmit();
    }

    public static List<int> GetPlayerNums()
    {
        return uiController.GetPlayerNums();
    }

    private static void SetIsPlayerWinner(int curRound, bool isPlayerWinner)
    {
        _isPlayerWinner = isPlayerWinner;
    }
}
