using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UI.TestScene
{
    public class FullScreenClickHandler : MonoBehaviour
    {
        private System.IDisposable _anyKeySubscription;

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
            Events.GameEvents.ShowMainMenu();
            gameObject.SetActive(false);
        }
    }
}

