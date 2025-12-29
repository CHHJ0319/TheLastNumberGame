using UnityEngine;
using TMPro;

public class TestCard : MonoBehaviour
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
