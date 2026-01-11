using Player;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

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

        [SerializeField] private GameObject roundDisplay;
        [SerializeField] private GameObject roundConters;
        [SerializeField] private TextMeshProUGUI targetNumDisplay;

        [Header("EndingScene")]
        [SerializeField] private GameObject winImage;
        [SerializeField] private GameObject defeatImage;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button retryButton;


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

        public void UpdateRoundDisplay(int round)
        {
            for (int i = 0; i < roundDisplay.transform.childCount; i++)
            {
                if (i == round - 1)
                {
                    roundDisplay.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    roundDisplay.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        public void SetRoundCounters(int curRound)
        {
            for (int i = 0; i < curRound; i++)
            {
                Transform child = roundConters.transform.GetChild(i);

                if (i > curRound - 1)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                    if(i <  curRound - 1)
                    {
                        child.gameObject.GetComponent<RoundCounter>().SetColor(true);
                    }
                    else
                    {
                        child.gameObject.GetComponent<RoundCounter>().SetColor(false);
                    }
                }
            }
        }

        public void SetEnemySprite(int round)
        {
            aiPlayer.SetEnemySprite(round);
        }

        public void UpdateTargetNumDisplay(int number)
        {
            targetNumDisplay.text = number.ToString();
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

        public void SetEndingSceneUI(bool isPlayerWinner)
        {
            if(isPlayerWinner)
            {
                winImage.gameObject.SetActive(true);
                defeatImage.gameObject.SetActive(false);

                nextButton.gameObject.SetActive(true);
                retryButton.gameObject.SetActive(false);
            }
            else
            {
                winImage.gameObject.SetActive(false);
                defeatImage.gameObject.SetActive(true);

                nextButton.gameObject.SetActive(false);
                retryButton.gameObject.SetActive(true);
            }
        }
    }
}


