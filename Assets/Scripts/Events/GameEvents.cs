using System;
using UnityEngine;

namespace Events 
{
    public static class GameEvents
    {
        public static Action OnFirstInput;

        public static void ResetEvents()
        {
            OnFirstInput = null;
        }

        public static void ShowMainMenu()
        {
            OnFirstInput?.Invoke();
        }
    }
}


