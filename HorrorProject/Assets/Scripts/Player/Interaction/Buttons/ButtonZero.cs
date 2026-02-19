using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonZero : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonZero = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonZero = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonZero = false;
    }

    public void ButtonZeroPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonZero && controller.playerCanInteract)
        {
            controller.b0();
            controller.textAmount += 1;
        }
    }
}
