using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace UI 
{
    public class UIController : MonoBehaviour
    {
        [Header("TitleScene")]
        [SerializeField] private GameObject startPrompt;
        [SerializeField] private GameObject menuButtons;

        [Header("GameScene")]
        [SerializeField] private Hand playerHand;
        [SerializeField] private Hand aiHand;

        [SerializeField] private TextMeshProUGUI targetNumDisplay;

        private void Awake()
        {
            UIManager.SetUIController(this);

            Events.GameEvents.OnFirstInput += ShowMainMenu;
            Events.PlayerEvents.OnPlayerTurnStarted += CreatePlayerHand;
            Events.AIEvents.OnAITurnStarted += CreateAIHand;
        }

        public void ShowMainMenu()
        {
            startPrompt.SetActive(false);
            menuButtons.SetActive(true);
        }

        public void CreatePlayerHand(int curNum, int targetNum)
        {
            StartCoroutine(playerHand.CreateHand(curNum, targetNum));
        }

        public void CreateAIHand(int curNum, int targetNum)
        {
            StartCoroutine(aiHand.CreateHand(curNum, targetNum));
        }

        public void UpdateTargetNumDisplay(int number)
        {
            targetNumDisplay.text = number.ToString();
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

        public List<int> GetPlayerNums()
        {
            return playerHand.GetselectedNums();
        }
    }
}


