using UnityEngine;
using UnityEngine.UI;

namespace UI.TitleScne
{
    public class TutorialButton : MonoBehaviour
    {
        public GameObject TutorialPanel;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            TutorialPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}