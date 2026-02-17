using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSeven : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonSeven = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonSeven = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonSeven = false;
    }

    public void ButtonSevenPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonSeven && interactor.playerInteraction)
        {
            interactor.b7();
            interactor.textAmount += 1;
        }
    }
}
