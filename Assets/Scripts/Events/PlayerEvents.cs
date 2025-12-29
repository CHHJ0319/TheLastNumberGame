using System;
using UnityEngine;

namespace Events
{
    public static class PlayerEvents
    {
        public static Action<int> OnPlayerTurnStarted;
        public static Action OnPlayerTurnFinished;

        public static void ResetEvents()
        {
            OnPlayerTurnStarted = null;
            OnPlayerTurnFinished = null;
        }

        public static void StartPlayerTurn(int curNum)
        {
            OnPlayerTurnStarted?.Invoke(curNum);
        }

        public static void FinishPlayerTurn()
        {
            OnPlayerTurnFinished?.Invoke();
        }
    }
}

