using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonNine : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonNine = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
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
        if (context.performed && isPlayerMouseOverButtonNine && interactor.playerInteraction)
        {   
            interactor.b9();
            interactor.textAmount += 1;
        }
    }
}
