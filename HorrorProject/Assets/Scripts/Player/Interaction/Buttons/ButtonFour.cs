using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonFour : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonFour = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonFour = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonFour = false;
    }

    public void ButtonFourPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonFour && interactor.playerInteraction)
        {
            interactor.b4();
            interactor.textAmount += 1;
        }
    }
}
