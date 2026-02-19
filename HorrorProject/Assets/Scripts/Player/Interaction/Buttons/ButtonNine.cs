using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonNine : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonNine = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonNine = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonNine = false;
    }

    public void ButtonNinePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonNine && controller.playerCanInteract)
        {   
            controller.b9();
            controller.textAmount += 1;
        }
    }
}
