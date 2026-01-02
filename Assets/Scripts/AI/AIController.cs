using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private UI.Hand hand;

    private int maxSelectable = 3;

    private List<int> winningNumbers;

    private Algorythm.NimStrategyCalculator calculator;

    public void Initalize (int targetNum)
    {
        calculator = new Algorythm.NimStrategyCalculator();

        winningNumbers = calculator.GenerateWinningNumbers(targetNum, maxSelectable);
    }

    public void CreateHand(int curNum, int targetNum)
    {
        StartCoroutine(hand.CreateHand(curNum, targetNum));
    }

    public int DecideHowManyToCall(int currentNum, int startNimStrategyPoint)
    {
        if (winningNumbers == null || winningNumbers.Count < startNimStrategyPoint || startNimStrategyPoint < 0)
        {
            return PickRandom();
        }

        if(startNimStrategyPoint == 0)
        {
            startNimStrategyPoint = winningNumbers.Count + 1;
        }

        for (int i = 0; i < winningNumbers.Count; i++)
        {
            int point = winningNumbers[i];
            if (point >= currentNum)
            {
                if (winningNumbers.Count - i < startNimStrategyPoint)
                {
                    int diff = point - currentNum + 1;

                    if (diff <= maxSelectable)
                    {
                        return diff;
                    }
                    break;
                }
                else
                {
                    PickRandom();
                    break;
                }
            }
        }

        return PickRandom();
    }

    private int PickRandom()
    {
        return Random.Range(1, maxSelectable + 1);
    }
}
