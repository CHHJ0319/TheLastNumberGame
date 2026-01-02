using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    public class SubmitButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            if (UIManager.CanSubmit())
            {
                Events.PlayerEvents.FinishPlayerTurn();
            }
            else
            {

            }
        }
    }
}


