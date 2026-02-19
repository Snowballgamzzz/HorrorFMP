using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonFour : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonFour = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonFour = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonFour = false;
    }

    public void ButtonFourPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonFour && controller.playerCanInteract)
        {
            controller.b4();
            controller.textAmount += 1;
        }
    }
}
