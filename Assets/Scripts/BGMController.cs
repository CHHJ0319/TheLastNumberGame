using UnityEngine;

public class BGMController : MonoBehaviour
{
    public static BGMController Instance; // 어디서든 부를 수 있게
    private AudioSource audioSource;

    void Awake()
    {
        // 1. 싱글톤 패턴 (이미 있으면 나는 자폭)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 핵심: 씬 넘어가도 파괴 안 됨
            audioSource = GetComponent<AudioSource>();

            // 오디오 소스 없으면 알아서 추가 (보험)
            if (audioSource == null)
                audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // 짝퉁은 사라져라
        }
    }

    void Start()
    {
        // 시작하자마자 루프 켜기 (BGM이니까)
        if (audioSource != null)
        {
            audioSource.loop = true;
            if (audioSource.clip != null) audioSource.Play();
        }
    }

    // 외부에서 음악 바꿀 때 쓰는 함수
    public void ChangeBGM(AudioClip newClip)
    {
        if (audioSource.clip == newClip) return; // 같은 노래면 무시

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}