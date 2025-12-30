

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Round
{
    public class RoundController : MonoBehaviour
    {
        private int targetNum = 0;
        private int curNum;
        private int nextNum;

        private bool isPlayerWinner;
        private bool isSelectionComplete;

        private List<int> playerNumbers;
        private List<int> aiNumbers;

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
            StartCoroutine(StartMainPhase(curRound));
            StartOutroPhase();
        }

        private void StartIntroPhase()
        {
            SetTargetNum();
        }

        private IEnumerator StartMainPhase(int curRound)
        {
            curNum = 1;
            if (playerFirstRounds.Contains(curRound))
            {
                while (true)
                {
                    yield return StartCoroutine(StartPlayerTurn());

                    nextNum = playerNumbers[^1];
                    curNum = nextNum + 1;
                    if (CheckTargetReached())
                    {
                        isPlayerWinner = false;
                        yield break;
                    }

                    yield return null;

                    //StartAITurn();
                    //lastNum = result[^1];

                    //if (CheckTargetReached(lastNum, targetNum))
                    //{
                    //    isPlayerWinner = true;
                    //    return;
                    //}
                }
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
            UIManager.UpdateTargetNumDisplay(targetNum);
        }

        private IEnumerator StartPlayerTurn()
        {
            Events.PlayerEvents.StartPlayerTurn(curNum, targetNum);

            while (!isSelectionComplete)
            {
                yield return null;
            }

            SetPlayerNumbers();
            isSelectionComplete = false;
        }

        //private IEnumerator StartAITurn()
        //{

        //}

        private bool CheckTargetReached()
        {
            return nextNum >= targetNum;
        }

        private void SetPlayerNumbers()
        {
            playerNumbers = UIManager.GetPlayerNums();
        }

        public void FinishPlayerTurn()
        {
            isSelectionComplete = true;
        }
    }
}
