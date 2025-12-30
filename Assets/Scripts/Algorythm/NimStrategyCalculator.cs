using System.Collections.Generic;

namespace Algorythm
{
    public class NimStrategyCalculator
    {
        public List<int> GenerateWinningNumbers(int targetNum, int maxSelectable)
        {
            List<int> winningNumbers = new List<int>();

            int currentWinningNum = targetNum - 1;
            int cycle = maxSelectable + 1;

            while (currentWinningNum > 0)
            {
                winningNumbers.Add(currentWinningNum);
                currentWinningNum -= cycle;
            }

            winningNumbers.Reverse();

            return winningNumbers;
        }
    }
}