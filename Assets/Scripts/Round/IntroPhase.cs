using UnityEngine;

namespace Round
{
    public class IntroPhase
    {
        public void StartPhase(ref int targetNum)
        {
            targetNum = SetTargetNum();
        }
            
        private int SetTargetNum() {
            int targetNum = Random.Range(13, 31);
            return targetNum;
        }
    }
}
