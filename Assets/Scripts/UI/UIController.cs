using Player;
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
        [SerializeField] private PlayerController player;
        [SerializeField] private AIController aiPlayer;

        [SerializeField] private GameObject roundConters;

        [SerializeField] private TextMeshProUGUI targetNumDisplay;

        private void OnEnable()
        {
            UIManager.SetUIController(this);

            Events.GameEvents.OnFirstInput += ShowMainMenu;
            Events.PlayerEvents.OnPlayerTurnStarted += CreatePlayerHand;
            Events.AIEvents.OnAITurnStarted += CreateAIHand;
        }

        private void OnDisable()
        {
            Events.GameEvents.OnFirstInput -= ShowMainMenu;
            Events.PlayerEvents.OnPlayerTurnStarted -= CreatePlayerHand;
            Events.AIEvents.OnAITurnStarted -= CreateAIHand;
        }

        public void ShowMainMenu()
        {
            startPrompt.SetActive(false);
            menuButtons.SetActive(true);
        }

        public void CreatePlayerHand(int curNum, int targetNum)
        {
            player.CreateHand(curNum, targetNum);
        }

        public void CreateAIHand(int curNum, int targetNum)
        {
            aiPlayer.CreateHand(curNum, targetNum);
        }

        public void UpdateTargetNumDisplay(int number)
        {
            targetNumDisplay.text = number.ToString();
        }

        public bool CanSubmit()
        {
            if (player.GetSelectedCount() > 0)
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
            return player.GetSelectedNums();
        }

        public void SetRoundCounters(int roundCount)
        {
            foreach (Transform child in roundConters.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}


