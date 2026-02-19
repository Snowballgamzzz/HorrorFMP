using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonThree : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonThree = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonThree = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonThree = false;
    }

    public void ButtonThreePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonThree && controller.playerCanInteract)
        {
            controller.b3();
            controller.textAmount += 1;
        }
    }
}
