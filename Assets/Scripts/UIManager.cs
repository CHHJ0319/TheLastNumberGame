using System.Collections.Generic;
using UI;
using UnityEngine;

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

    public static void SetGameScene(int curRound)
    {
        if (uiController != null)
        {
            uiController.SetRoundCounters(curRound);
        }
    }

    public static void UpdateRoundDisplay(int round)
    {
        uiController.UpdateRoundDisplay(round);
    }

    public static void SetEnemySprite(int round)
    {
        uiController.SetEnemySprite(round);
    }

    public static void UpdateTargetNumDisplay(int number)
    {
        uiController.UpdateTargetNumDisplay(number);
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

    public static void SetIntroSceneDialogText(int index)
    {
        string dialog = "";
        switch (index)
        {
            case 0:
                dialog = Text.IntroSceneText.Text1;
                break;
            case 1:
                dialog = Text.IntroSceneText.Text2;
                break;
            case 2:
                dialog = Text.IntroSceneText.Text3;
                break;
            case 3:
                dialog = Text.IntroSceneText.Text4;
                break;
            case 4:
                dialog = Text.IntroSceneText.Text5;
                break;
        }

        uiController.SetDialogText(dialog);
    }

    public static void SetStartDialogText(int round)
    {
        Data.EnemyData enemy = ActorManager.Enemies[round - 1];

        uiController.SetDialogText(enemy.StartMessage);
    }

    public static void SetRandomDialogText(int round)
    {
        Data.EnemyData enemy = ActorManager.Enemies[round - 1];

        int index = Random.Range(0, 3);
        switch (index) 
        {
            case 0:
                uiController.SetDialogText(enemy.RandomMessage1);
                break;
            case 1:
                uiController.SetDialogText(enemy.RandomMessage2);
                break;
            case 2:
                uiController.SetDialogText(enemy.RandomMessage3);
                break;
        }
    }

    public static void SetDefeatDialogText(int round)
    {
        Data.EnemyData enemy = ActorManager.Enemies[round - 1];

        uiController.SetDialogText(enemy.DefeatMessage);
    }

    public static void SetWinDialogText(int round)
    {
        Data.EnemyData enemy = ActorManager.Enemies[round - 1];

        uiController.SetDialogText(enemy.WinMessage);
    }
}
