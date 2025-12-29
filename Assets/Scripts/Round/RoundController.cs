

namespace Round
{
    public class RoundController
    {
        private int targetNum = 0;
        private bool isPlayerWinner;

        private IntroPhase introPhase;
        private MainPhase mainPhase;
        private OutroPhase outroPhase;


        public void Initialize ()
        {
            introPhase = new IntroPhase();
            mainPhase = new MainPhase();
            outroPhase = new OutroPhase();
        }

        public void StartRound(int curRound)
        {
            introPhase.StartPhase(ref targetNum);
            mainPhase.StartPhase(curRound, targetNum, ref isPlayerWinner);
            outroPhase.StartPhase(isPlayerWinner);
        }

    }
}
