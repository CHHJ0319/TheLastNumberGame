using UnityEngine;

namespace UI 
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Hand playerHand;
        [SerializeField] private Hand aiHand;

        private void Awake()
        {
            UIManager.SetUIController(this);
            Events.PlayerEvents.OnPlayerTurnStarted += CreatePlayerHand;
        }

        public void CreatePlayerHand(int curNum)
        {
            StartCoroutine(playerHand.CreateHand(curNum));
        }

        public bool CanSubmit()
        {
            if (playerHand.GetSelectedCount() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


