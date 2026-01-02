

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Round
{
    public class RoundController : MonoBehaviour
    {
        public AIController aIController;

        private int targetNum = 0;
        private int curNum;
        private int nextNum;

        private bool isPlayerWinner;
        private bool isSelectionComplete;

        private List<int> playerNumbers;
        private List<int> aiNumbers;

        private readonly HashSet<int> playerFirstRounds = new HashSet<int> { 1, 3, 4, 6, 7, 9, 10 };

        private void OnEnable()
        {
            RoundManager.SetRoundController(this);

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
            aiNumbers = new List<int>();
            SetAIStrategy();
        }

        private IEnumerator StartMainPhase(int curRound)
        {
            curNum = 1;
            if (!playerFirstRounds.Contains(curRound))
            {
                while (true)
                {
                    yield return StartCoroutine(StartPlayerTurn());
                    nextNum = playerNumbers[^1];
                    if (CheckTargetReached())
                    {
                        isPlayerWinner = false;
                        yield break;
                    }

                    curNum = nextNum + 1;
                    yield return null;

                    yield return StartCoroutine(StartAITurn());
                    nextNum = aiNumbers[^1];
                    if (CheckTargetReached())
                    {
                        isPlayerWinner = true;
                        yield break;
                    }

                    curNum = nextNum + 1;
                    yield return null;
                }
            }
            else
            {
                while (true)
                {
                    yield return StartCoroutine(StartAITurn());
                    nextNum = aiNumbers[^1];
                    if (CheckTargetReached())
                    {
                        isPlayerWinner = true;
                        yield break;
                    }

                    curNum = nextNum + 1;
                    yield return null;

                    yield return StartCoroutine(StartPlayerTurn());
                    nextNum = playerNumbers[^1];
                    if (CheckTargetReached())
                    {
                        isPlayerWinner = false;
                        yield break;
                    }

                    curNum = nextNum + 1;
                    yield return null;
                }
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

        private void SetAIStrategy()
        {
            aIController.Initalize(targetNum);
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

        private IEnumerator StartAITurn()
        {
           // Events.AIEvents.StartAITurn(curNum, targetNum);
            int countToCall = aIController.DecideHowManyToCall(curNum, 3);

            aiNumbers = new List<int>();
            for (int i = 0; i < countToCall; i++)
            {
                aiNumbers.Add(curNum + i);
            }

            yield return null;
        }

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
