using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public UnityEvent OnClickEvent;

    private void Awake()
    {
        Instance = this;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnClickEvent?.Invoke();
        }
    }
}
