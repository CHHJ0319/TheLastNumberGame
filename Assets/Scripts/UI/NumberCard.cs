using UnityEngine;
using TMPro;

namespace UI
{
    public class NumberCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cardText;

        public void SetNumber(int number)
        {
            if (cardText != null)
            {
                cardText.text = number.ToString();
            }
        }
    }
}

