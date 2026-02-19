using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonEight : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonEight = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonEight = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonEight = false;
    }

    public void ButtonEightPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonEight && controller.playerCanInteract)
        {
            controller.b8();
            controller.textAmount += 1;
        }
    }
}
