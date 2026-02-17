using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonFive : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonFive = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonFive = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonFive = false;
    }

    public void ButtonFivePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonFive && interactor.playerInteraction)
        {
            interactor.b5();
            interactor.textAmount += 1;
        }
    }
}
