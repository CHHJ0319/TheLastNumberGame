using System;
using UnityEngine;

namespace Events
{
    public static class PlayerEvents
    {
        public static Action<int, int> OnPlayerTurnStarted;
        public static Action OnPlayerTurnFinished;

        public static void ResetEvents()
        {
            OnPlayerTurnStarted = null;
            OnPlayerTurnFinished = null;
        }

        public static void StartPlayerTurn(int curNum, int targetNum)
        {
            OnPlayerTurnStarted?.Invoke(curNum, targetNum);
        }

        public static void FinishPlayerTurn()
        {
            OnPlayerTurnFinished?.Invoke();
        }
    }
}

