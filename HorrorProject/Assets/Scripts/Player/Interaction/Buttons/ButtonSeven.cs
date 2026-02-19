using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSeven : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonSeven = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonSeven = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonSeven = false;
    }

    public void ButtonSevenPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonSeven && controller.playerCanInteract)
        {
            controller.b7();
            controller.textAmount += 1;
        }
    }
}
