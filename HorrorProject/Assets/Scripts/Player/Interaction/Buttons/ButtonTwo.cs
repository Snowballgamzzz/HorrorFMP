using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonTwo : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonTwo = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonTwo = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonTwo = false;
    }

    public void ButtonTwoPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonTwo && interactor.playerInteraction)
        {
            interactor.b2();
            interactor.textAmount += 1;
        }
    }
}
