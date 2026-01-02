using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

namespace UI
{
    public class FullScreenClickHandler : MonoBehaviour
    {
        private System.IDisposable _anyKeySubscription;

        private string targetSceneName = "GameScene";

        void OnEnable()
        {
            _anyKeySubscription = InputSystem.onAnyButtonPress.Call(control =>
            {
                if (control is UnityEngine.InputSystem.Controls.ButtonControl)
                {
                    if (Pointer.current != null)
                    {
                        Vector2 mousePos = Pointer.current.position.ReadValue();
                        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

                        if (screenRect.Contains(mousePos))
                        {
                            HandleAnyInput();
                        }
                    }
                    else
                    {
                        HandleAnyInput();
                    }
                }
            });
        }

        void OnDisable()
        {
            _anyKeySubscription?.Dispose();
        }

        void HandleAnyInput()
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "TitleScene")
            {
                Events.GameEvents.ShowMainMenu();
                gameObject.SetActive(false);
            }
            else if (sceneName == "IntroScene")
            {
                Algorythm.SceneLoader.LoadSceneByName(targetSceneName);
            }
        }
    }
}

