using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSix : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonSix = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonSix = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonSix = false;
    }

    public void ButtonSixPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonSix && controller.playerCanInteract)
        {
            controller.b6();
            controller.textAmount += 1;
        }
    }
}
