using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private UI.Hand hand;
        
        public void CreateHand(int curNum, int targetNum)
        {
            StartCoroutine(hand.CreateHand(curNum, targetNum));
        }

        public int GetSelectedCount()
        {
            return hand.GetSelectedCount();
        }

        public List<int> GetSelectedNums()
        {
            return hand.GetSelectedNums();
        }
    }
}

