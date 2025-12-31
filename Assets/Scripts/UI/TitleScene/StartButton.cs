using UnityEngine;
using UnityEngine.UI;

namespace UI.TestScene
{
    public class MenuButton : MonoBehaviour
    {
        private string targetSceneName = "GameScene";
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            SceneLoader.LoadSceneByName(targetSceneName);
        }
    }
}

