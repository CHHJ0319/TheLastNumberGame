using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    public class ExitButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(QuitGame);
        }

        public void QuitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}


