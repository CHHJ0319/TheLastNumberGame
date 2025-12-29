using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Hand : MonoBehaviour
    {
        public GameObject cardPrefab;

        private float spawnDelay = 0.2f;

        private int startNum;
        private List<int> selectedNumbers = new List<int>();

        public IEnumerator CreateHand(int curNum)
        {
            startNum = curNum;
            for (int i = 0; i < 3; i++)
            {
                CreateCard(curNum + i);
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        public int GetSelectedCount()
        {
            return selectedNumbers.Count;
        }

        private void CreateCard(int num)
        {
            GameObject newCard = Instantiate(cardPrefab, transform);
            TestCard cardScript = newCard.GetComponent<TestCard>();
            if (cardScript != null)
            {
                cardScript.SetNumber(num);
            }
            Button btn = newCard.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => OnCardSelected(num, newCard, btn));
            }
        }

        private void OnCardSelected(int clickedNum, GameObject cardObj, Button btn)
        {
            if (selectedNumbers.Contains(clickedNum))
            {
                HandleCancel(clickedNum, cardObj, btn);
            }
            else
            {
                HandleSelect(clickedNum, cardObj, btn);
            }
        }

        private void HandleSelect(int clickedNum, GameObject cardObj, Button btn)
        {
            bool isValid = (selectedNumbers.Count == 0 && clickedNum == startNum) ||
                           (selectedNumbers.Count > 0 && clickedNum == selectedNumbers[^1] + 1);

            if (isValid)
            {
                selectedNumbers.Add(clickedNum);
                SetCardVisual(cardObj, true);
            }
            else
            {
            }
        }

        private void HandleCancel(int clickedNum, GameObject cardObj, Button btn)
        {
            if (selectedNumbers[^1] == clickedNum)
            {
                selectedNumbers.RemoveAt(selectedNumbers.Count - 1);
                SetCardVisual(cardObj, false); 
            }
            else
            {
            }
        }

        private void SetCardVisual(GameObject cardObj, bool isSelected)
        {
            var image = cardObj.GetComponent<Image>();
            image.color = isSelected ? Color.gray : Color.white;
        }
    }
}

