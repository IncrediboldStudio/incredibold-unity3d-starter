using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, InputActions.IPlayerActions
{
    private PlayerInput playerInput;
    public PlayerInput PlayerInput => playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        LogContext(context);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LogContext(context);
    }

    private static void LogContext(InputAction.CallbackContext context)
    {
        Debug.Log($"{context.action.name}, {context.valueType}");
    }
}
