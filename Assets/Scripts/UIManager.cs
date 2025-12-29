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
}
