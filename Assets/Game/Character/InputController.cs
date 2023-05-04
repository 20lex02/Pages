using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputController : MonoBehaviour
{
    private PlayerInput _playerInput;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void GotoPlayMode()
    {
        _playerInput.notificationBehavior = PlayerNotifications.SendMessages;
        _playerInput.SwitchCurrentActionMap("Player");
    }

    public void GotoHUDMode()
    {
        _playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        _playerInput.SwitchCurrentActionMap("HUD");
    }

    public void AddActionBinding(string actionName, System.Action<InputAction.CallbackContext> action)
    {
        _playerInput.actions[actionName].performed += action;
    }
}