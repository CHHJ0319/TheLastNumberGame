

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Round
{
    public class RoundController : MonoBehaviour
    {
        private int targetNum = 0;
        private bool isPlayerWinner;
        private int curNum;
        private bool isSelectionComplete;

        private List<int> playerChoices;
        private List<int> aiChoices;

        private IntroPhase introPhase;
        private OutroPhase outroPhase;

        private readonly HashSet<int> playerFirstRounds = new HashSet<int> { 1, 3, 4, 6, 7, 9, 10 };

        private void Awake()
        {
            RoundManager.SetRoundController(this);
        }

        public void Initialize ()
        {
            introPhase = new IntroPhase();
            outroPhase = new OutroPhase();

            Events.PlayerEvents.OnPlayerTurnFinished += FinishPlayerTurn;
        }

        public void StartRound(int curRound)
        {
            introPhase.StartPhase(ref targetNum);
            StartMainPhase(curRound, targetNum, ref isPlayerWinner);
            outroPhase.StartPhase(isPlayerWinner);
        }

        public void StartMainPhase(int curRound, int targetNum, ref bool isPlayerWinner)
        {
            curNum = 1;
            if (playerFirstRounds.Contains(curRound))
            {
                //while(true)
                //{
                StartCoroutine(StartPlayerTurn(curNum));
                //int lastNum = result[^1];

                //if (CheckTargetReached(lastNum, targetNum))
                //{
                //    isPlayerWinner = false;
                //    return;
                //}

                //StartAITurn();
                //lastNum = result[^1];

                //if (CheckTargetReached(lastNum, targetNum))
                //{
                //    isPlayerWinner = true;
                //    return;
                //}
                //}
            }
            else
            {
                //while (true)
                //{
                //    var result = StartAITurn();
                //    int lastNum = result[^1];

                //    if (CheckTargetReached(lastNum, targetNum))
                //    {
                //        isPlayerWinner = true;
                //        return;
                //    }

                //    result = StartPlayerTurn(curNum);
                //    lastNum = result[^1];

                //    if (CheckTargetReached(lastNum, targetNum))
                //    {
                //        isPlayerWinner = false;
                //        return;
                //    }
                //}
            }
        }

        private IEnumerator StartPlayerTurn(int curNum)
        {
            Events.PlayerEvents.StartPlayerTurn(curNum);

            while (!isSelectionComplete)
            {
                yield return null;
            }

            int a = 1;
        }

        //private IEnumerator StartAITurn()
        //{

        //}

        private bool CheckTargetReached(int lastNumber, int target)
        {
            return lastNumber >= target;
        }

        public void FinishPlayerTurn()
        {
            isSelectionComplete = true;
        }
    }
}
