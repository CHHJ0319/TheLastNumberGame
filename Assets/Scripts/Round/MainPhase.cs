using System.Collections.Generic;

namespace Round {
    public class MainPhase
    {
        private int curNum;

        private readonly HashSet<int> playerFirstRounds = new HashSet<int> { 1, 3, 4, 6, 7, 9, 10 };

        public void StartPhase(int curRound, int targetNum, ref bool isPlayerWinner)
        {
            curNum = 1;
            if (playerFirstRounds.Contains(curRound))
            {
                //while(true)
                //{

                var result = PlayPlayerTurn(curNum);
                int lastNum = result[^1];
                
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
                //}
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

                    result = PlayPlayerTurn(curNum);
                    lastNum = result[^1];

                    if (CheckTargetReached(lastNum, targetNum))
                    {
                        isPlayerWinner = false;
                        return;
                    }
                }
            }
        }

        private List<int> PlayPlayerTurn(int curNum)
        {
            Events.PlayerEvents.StartPlayerTurn(curNum);

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


