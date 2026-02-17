using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonEnter : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonEnter = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
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
            interactor.enterEvent();
        }
    }
}
