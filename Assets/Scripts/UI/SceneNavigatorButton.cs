using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SceneNavigatorButton : MonoBehaviour
    {
        public string targetScene;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(LoadScene);
        }

        public void LoadScene()
        {
            Algorythm.SceneLoader.LoadSceneByName(targetScene);
        }
    }
}
