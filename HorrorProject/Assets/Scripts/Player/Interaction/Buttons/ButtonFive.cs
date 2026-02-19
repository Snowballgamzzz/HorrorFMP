using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonFive : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonFive = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonFive = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonFive = false;
    }

    public void ButtonFivePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonFive && controller.playerCanInteract)
        {
            controller.b5();
            controller.textAmount += 1;
        }
    }
}
