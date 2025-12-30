using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private int maxSelectable = 3;

    private List<int> winningNumbers;

    private Algorythm.NimStrategyCalculator calculator;

    public void Initalize (int targetNum)
    {
        calculator = new Algorythm.NimStrategyCalculator();

        winningNumbers = calculator.GenerateWinningNumbers(targetNum, maxSelectable);
    }

    public int DecideHowManyToCall(int currentNum)
    {
        foreach (int point in winningNumbers)
        {
            if (point >= currentNum)
            {
                int diff = point - currentNum + 1;

                if (diff <= maxSelectable)
                {
                    return diff;
                }
                break;
            }
        }

        return Random.Range(1, maxSelectable + 1);
    }
}
