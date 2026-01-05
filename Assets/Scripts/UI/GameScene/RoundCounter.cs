using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RoundCounter : MonoBehaviour
    {
        private Image uiImg;

        private void Awake ()
        {
            uiImg = GetComponent<Image>();
        }

        public void Show(bool isPlayerWinner)
        {
            SetColor(isPlayerWinner);
        }

        public void SetColor(bool isPlayerWinner)
        {
            if (isPlayerWinner)
            {
                uiImg.color = new Color(255.0f / 255.0f, 175.0f / 255.0f, 0f);
            }
            else {
                uiImg.color = new Color(0f, 250.0f / 255.0f, 255.0f/255.0f);
            }
        }
    }
}

