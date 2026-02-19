using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClear : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonClear = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonClear = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonClear = false;
    }

    public void ButtonClearPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonClear)
        {
            controller.clearEvent();
            controller.textAmount = 0;
            controller.playerCanInteract = true;
        }
    }
}
