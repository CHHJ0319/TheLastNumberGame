using System;
using UnityEngine;

namespace Events
{
    public static class AIEvents
    {
        public static Action<int, int> OnAITurnStarted;
        public static Action OnAITurnFinished;

        public static void Clear()
        {
            OnAITurnStarted = null;
            OnAITurnFinished = null;
        }

        public static void StartAITurn(int curNum, int targetNum)
        {
            OnAITurnStarted?.Invoke(curNum, targetNum);
        }

        public static void FinishAITurn()
        {
            OnAITurnFinished?.Invoke();
        }
    }
}

