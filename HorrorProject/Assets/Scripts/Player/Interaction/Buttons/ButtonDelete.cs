using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonDelete : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonDelete = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonDelete = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonDelete = false;
    }

    public void ButtonDeletePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonDelete)
        {
            controller.deleteEvent();
            controller.textAmount -= 1;
        }
    }
}
