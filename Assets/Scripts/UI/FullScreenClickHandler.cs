using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace UI
{
    public class FullScreenClickHandler : MonoBehaviour
    {
        private System.IDisposable _anyKeySubscription;
        private string targetSceneName = "GameScene";

        [Header("Sound Settings")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;

        private bool isProcessed = false;

        private int clickCount = 0;

        void OnEnable()
        {
            isProcessed = false;

            _anyKeySubscription = InputSystem.onAnyButtonPress.Call(control =>
            {
                if (isProcessed) return;

                if (control is UnityEngine.InputSystem.Controls.ButtonControl)
                {
                    if (Pointer.current != null)
                    {
                        Vector2 mousePos = Pointer.current.position.ReadValue();
                        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

                        if (screenRect.Contains(mousePos)) HandleAnyInput();
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

        async void HandleAnyInput()
        {
            isProcessed = true;

            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
                await Awaitable.WaitForSecondsAsync(clickSound.length);
            }

            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "TitleScene")
            {
                _anyKeySubscription?.Dispose();
                Events.GameEvents.ShowMainMenu();
                gameObject.SetActive(false);
            }
            else if (sceneName == "IntroScene")
            {
                clickCount++;
                if(clickCount > 4)
                {
                    _anyKeySubscription?.Dispose();
                    Algorythm.SceneLoader.LoadSceneByName(targetSceneName);
                    clickCount = 0;
                }
                else
                {
                    isProcessed = false;
                    UIManager.SetIntroSceneDialogText(clickCount);
                }
            }
        }
    }
}