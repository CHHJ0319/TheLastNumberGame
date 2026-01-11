using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TitleScne
{
    public class TutorialPanel : MonoBehaviour
    {
        public Button quitBtn;
        public Button previousBtn;
        public Button nextBtn;
        
        public Image[] descriptionImgs;

        public TextMeshProUGUI descriptionText;

        public GameObject tutorialBtn;

        private int tutorialIndex = 0;
        private string[] descriptionTexts;

        void Start()
        {
            SetButtonAction();
            SetDescriptionTexts();

            SetTutorialPanel();
        }

        private void SetButtonAction()
        {
            quitBtn.onClick.AddListener(OnQuitButtonClicked);
            previousBtn.onClick.AddListener(OnPreviousButtonClicked);
            nextBtn.onClick.AddListener(OnNextButtonClicked);
        }

        private void SetDescriptionTexts()
        {
            descriptionTexts = new string[4];

            descriptionTexts[0] = Text.TutorialText.TutorialText1;
            descriptionTexts[1] = Text.TutorialText.TutorialText2;
            descriptionTexts[2] = Text.TutorialText.TutorialText3;
            descriptionTexts[3] = Text.TutorialText.TutorialText4;
        }

        private void SetTutorialPanel()
        {
            ShowTutorialButton();
            ShowDescription();
        }

        private void ShowTutorialButton()
        {
            if (tutorialIndex > 0)
            {
                previousBtn.gameObject.SetActive(true);
            }
            else
            {
                previousBtn.gameObject.SetActive(false);
            }

            if (tutorialIndex < 3)
            {
                nextBtn.gameObject.SetActive(true);
            }
            else
            {
                nextBtn.gameObject.SetActive(false);
            }
        }

        private void ShowDescription()
        {
            for (int i = 0; i < 4; i++)
            {
                if(i == tutorialIndex)
                {
                    descriptionImgs[i].gameObject.SetActive(true);
                }
                else
                {
                    descriptionImgs[i].gameObject.SetActive(false);
                }
            }
            descriptionText.text = descriptionTexts[tutorialIndex];
        }

        private void OnQuitButtonClicked()
        {
            tutorialIndex = 0;
            SetTutorialPanel();

            gameObject.SetActive(false);
            tutorialBtn.SetActive(true);
        }

        private void OnPreviousButtonClicked()
        {
            tutorialIndex--;
            SetTutorialPanel();
        }

        private void OnNextButtonClicked()
        {
            tutorialIndex++;
            SetTutorialPanel();
        }
    }
}

