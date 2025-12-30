using System.Collections.Generic;
using UI;

public static class UIManager
{
    private static UIController uiController;
    public static void SetUIController(UIController controller)
    {
        uiController = controller;
    }

    public static bool CanSubmit()
    {
        return uiController.CanSubmit();
    }

    public static List<int> GetPlayerNums()
    {
        return uiController.GetPlayerNums();
    }

    public static void UpdateTargetNumDisplay(int number)
    {
        uiController.UpdateTargetNumDisplay(number);
    }
}
