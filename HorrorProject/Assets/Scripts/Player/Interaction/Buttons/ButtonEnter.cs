using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonEnter : MonoBehaviour
{
    SafeController controller;
    public GameObject safeDoor;

    public bool isPlayerMouseOverButtonEnter = false;

    private void Start()
    {
        controller = safeDoor.GetComponent<SafeController>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonEnter = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonEnter = false;
    }

    public void ButtonEnterPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonEnter)
        {           
            controller.enterEvent();
        }
    }
}
