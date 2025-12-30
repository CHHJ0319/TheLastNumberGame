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
        private List<int> selectedNums = new List<int>();

        public IEnumerator CreateHand(int curNum, int targetNum)
        {
            startNum = curNum;
            selectedNums = new List<int>();
            ClearHand();

            for (int i = 0; i < 3; i++)
            {
                int cardNum = curNum + i;
                if(cardNum <= targetNum)
                {
                    CreateCard(cardNum);
                    yield return new WaitForSeconds(spawnDelay);
                }

            }
        }

        public int GetSelectedCount()
        {
            return selectedNums.Count;
        }

        public List<int> GetselectedNums()
        {
            return new List<int>(selectedNums);
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

        public void ClearHand()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        private void OnCardSelected(int clickedNum, GameObject cardObj, Button btn)
        {
            if (selectedNums.Contains(clickedNum))
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
            bool isValid = (selectedNums.Count == 0 && clickedNum == startNum) ||
                           (selectedNums.Count > 0 && clickedNum == selectedNums[^1] + 1);

            if (isValid)
            {
                selectedNums.Add(clickedNum);
                SetCardVisual(cardObj, true);
            }
            else
            {
            }
        }

        private void HandleCancel(int clickedNum, GameObject cardObj, Button btn)
        {
            if (selectedNums[^1] == clickedNum)
            {
                selectedNums.RemoveAt(selectedNums.Count - 1);
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

