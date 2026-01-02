using UnityEngine;
using UnityEngine.UI;

namespace UI.TestScene
{
    public class StartButton : MonoBehaviour
    {
        private string targetSceneName = "IntroScene";

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            Algorythm.SceneLoader.LoadSceneByName(targetSceneName);
        }
    }
}

