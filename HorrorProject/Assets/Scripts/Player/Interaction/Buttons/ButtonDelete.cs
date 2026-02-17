using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonDelete : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonDelete = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
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
            interactor.deleteEvent();
            interactor.textAmount -= 1;
        }
    }
}
