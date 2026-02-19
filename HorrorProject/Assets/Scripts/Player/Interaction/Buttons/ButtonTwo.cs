using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonTwo : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonTwo = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonTwo = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonTwo = false;
    }

    public void ButtonTwoPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonTwo && controller.playerCanInteract)
        {
            controller.b2();
            controller.textAmount += 1;
        }
    }
}
