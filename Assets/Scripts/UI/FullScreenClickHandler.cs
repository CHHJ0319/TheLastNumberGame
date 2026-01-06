using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using System.Threading.Tasks; // [추가 1] 이거 필수

namespace UI
{
    public class FullScreenClickHandler : MonoBehaviour
    {
        private System.IDisposable _anyKeySubscription;
        private string targetSceneName = "GameScene";

        // [추가 2] 인스펙터에서 소리 넣을 변수
        [Header("Sound Settings")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;

        // [추가 3] 광클/중복 방지용 깃발
        private bool isProcessed = false;

        void OnEnable()
        {
            isProcessed = false; // 켜질 때마다 초기화

            _anyKeySubscription = InputSystem.onAnyButtonPress.Call(control =>
            {
                if (isProcessed) return; // 이미 눌렀으면 무시

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

        // [수정] async void로 변경 (비동기 대기 위해)
        async void HandleAnyInput()
        {
            isProcessed = true; // 중복 실행 방지
            _anyKeySubscription?.Dispose(); // 더 이상 입력 안 받음

            // [추가 4] 소리 재생 및 대기 로직
            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
                // 소리 길이만큼 대기 (유니티 6.0 신기술)
                await Awaitable.WaitForSecondsAsync(clickSound.length);
            }

            // 기존 로직 실행
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "TitleScene")
            {
                Events.GameEvents.ShowMainMenu();
                gameObject.SetActive(false); // 소리 다 듣고 나서 꺼짐
            }
            else if (sceneName == "IntroScene")
            {
                Algorythm.SceneLoader.LoadSceneByName(targetSceneName);
            }
        }
    }
}