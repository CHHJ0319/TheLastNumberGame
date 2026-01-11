using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RetryButton : MonoBehaviour
    {
        private string targetScene = "TitleScene";

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(LoadScene);
        }

        public void LoadScene()
        {
            RoundManager.ResetRoundData();
            Algorythm.SceneLoader.LoadSceneByName(targetScene);
        }
    }
}
