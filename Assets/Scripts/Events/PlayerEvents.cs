using System;
using UnityEngine;

namespace Events
{
    public static class PlayerEvents
    {
        public static Action<int> OnPlayerTurnStarted;

        public static void ResetEvents()
        {
            OnPlayerTurnStarted = null;
        }

        public static void StartPlayerTurn(int curNum)
        {
            OnPlayerTurnStarted?.Invoke(curNum);
        }

    }
}

