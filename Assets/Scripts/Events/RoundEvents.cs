using System;
using UnityEngine;

namespace Events 
{
    public static class RoundEvents
    {
        public static Action<int, bool> OnRoundEnded;

        public static void Clear()
        {
            OnRoundEnded = null;
        }

        public static void RecordRoundResult(int curRound, bool isPlayerWinner)
        {
            OnRoundEnded?.Invoke(curRound, isPlayerWinner);
        }
    }
}


