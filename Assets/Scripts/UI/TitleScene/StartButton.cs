using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; // [필수] Awaitable 쓰려면 이거 있어야 함

namespace UI.TitleScne
{
    public class StartButton : MonoBehaviour
    {
        // [수정 1] 인스펙터에서 씬 이름 바꿀 수 있게 SerializeField 추가
        // Start 버튼은 IntroScene, Continue 버튼은 GameScene으로 적으면 됨
        [SerializeField] private string targetSceneName = "IntroScene";

        // [수정 2] 소리 설정 변수 추가
        [Header("Sound Settings")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;

        private Button btn; // 버튼 캐싱

        private void Start()
        {
            btn = GetComponent<Button>();
            // 람다식 안 쓰고 함수 직접 연결 (깔끔하게)
            btn.onClick.AddListener(OnClicked);
        }

        // [수정 3] async void로 변경 (비동기 대기)
        private async void OnClicked()
        {
            // 광클 방지 (이거 안 하면 따닥! 하고 두 번 실행됨)
            btn.interactable = false;

            // 1. 소리 재생 & 대기
            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);

                // 유니티 6.0 신기술: 소리 길이만큼 딱 기다림
                await Awaitable.WaitForSecondsAsync(clickSound.length);
            }

            // 2. 씬 로드 (소리 다 듣고 나서 실행)
            Algorythm.SceneLoader.LoadSceneByName(targetSceneName);
        }
    }
}