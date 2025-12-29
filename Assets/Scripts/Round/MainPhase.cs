using System.Collections.Generic;

namespace Round {
    public class MainPhase
    {
        private int curNum = 0;

        private readonly HashSet<int> playerFirstRounds = new HashSet<int> { 1, 3, 4, 6, 7, 9, 10 };

        public void StartPhase(int curRound, int targetNum, ref bool isPlayerWinner)
        {

            if (playerFirstRounds.Contains(curRound))
            {
                var result = PlayPlayerTurn();
                int lastNum = result[^1];

                while(true)
                {
                    if (CheckTargetReached(lastNum, targetNum))
                    {
                        isPlayerWinner = false;
                        return;
                    }

                    result = PlayAITurn();
                    lastNum = result[^1];

                    if (CheckTargetReached(lastNum, targetNum))
                    {
                        isPlayerWinner = true;
                        return;
                    }
                }
            }
            else
            {
                while (true)
                {
                    var result = PlayAITurn();
                    int lastNum = result[^1];

                    if (CheckTargetReached(lastNum, targetNum))
                    {
                        isPlayerWinner = true;
                        return;
                    }

                    result = PlayPlayerTurn();
                    lastNum = result[^1];

                    if (CheckTargetReached(lastNum, targetNum))
                    {
                        isPlayerWinner = false;
                        return;
                    }
                }
            }
        }

        private List<int> PlayPlayerTurn()
        {
            List<int> choices = new List<int> { 1 };
            return choices;
        }

        private List<int> PlayAITurn()
        {
            List<int> choices = new List<int> { 1 };
            return choices;
        }

        private bool CheckTargetReached(int lastNumber, int target)
        {
            return lastNumber >= target;
        }
    }
}


