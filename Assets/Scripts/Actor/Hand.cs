using System.Collections;
using UnityEngine;

namespace Actor
{
    public class Hand : MonoBehaviour
    {
        public GameObject cardPrefab;

        private float spawnDelay = 0.2f; 

        public IEnumerator CreateHand(int curNum)
        {
            for (int i = 0; i < 3; i++)
            {
                CreateCard(curNum + i);
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        private void CreateCard(int num)
        {
            GameObject newCard = Instantiate(cardPrefab, transform);
            TestCard cardScript = newCard.GetComponent<TestCard>();
            if (cardScript != null)
            {
                cardScript.SetNumber(num);
            }
        }
    }
}

