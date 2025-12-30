

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Round
{
    public class RoundController : MonoBehaviour
    {
        private int targetNum = 0;
        private int curNum;

        private bool isPlayerWinner;
        private bool isSelectionComplete;

        private List<int> playerChoices;
        private List<int> aiChoices;

        private readonly HashSet<int> playerFirstRounds = new HashSet<int> { 1, 3, 4, 6, 7, 9, 10 };

        private void Awake()
        {
            RoundManager.SetRoundController(this);
        }

        public void Initialize ()
        {
            Events.PlayerEvents.OnPlayerTurnFinished += FinishPlayerTurn;
        }

        public void StartRound(int curRound)
        {
            StartIntroPhase();
            StartMainPhase(curRound);
            StartOutroPhase();
        }

        private void StartIntroPhase()
        {
            SetTargetNum();
        }

        private void StartMainPhase(int curRound)
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
        private void StartOutroPhase()
        {
            
        }


        private void SetTargetNum()
        {
            targetNum = Random.Range(13, 31);
        }

        private IEnumerator StartPlayerTurn(int curNum)
        {
            Events.PlayerEvents.StartPlayerTurn(curNum);

            while (!isSelectionComplete)
            {
                yield return null;
            }

            isSelectionComplete = false;
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
