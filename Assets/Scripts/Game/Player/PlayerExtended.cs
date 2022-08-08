using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerExtended : MonoBehaviour
{
    public Action OnClickFromPlayer;
    public Action OnNextDialog;
    public Action<int> OnKeyOptionPress;
    public void OnClick(InputAction.CallbackContext value)
    {
        if (value.canceled)
        {
            OnClickFromPlayer?.Invoke();
        }
    }
    
    public void OnSkipDialog(InputAction.CallbackContext value)
    {
        OnNextDialog?.Invoke();
    }
    
    public void OnNumberKeys(InputAction.CallbackContext value)
    {
        if (value.canceled)
        {
            Debug.Log($"{value.control.name}");
            OnKeyOptionPress?.Invoke(int.Parse(value.control.name));
        }
    }
}