using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonOne : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonOne = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonOne = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonOne = false;
    }

    public void ButtonOnePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonOne && controller.playerCanInteract)
        {
            controller.b1();
            controller.textAmount += 1;
        }
    }
}
