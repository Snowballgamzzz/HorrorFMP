using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSix : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonSix = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonSix = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonSix = false;
    }

    public void ButtonSixPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonSix && interactor.playerInteraction)
        {
            interactor.b6();
            interactor.textAmount += 1;
        }
    }
}
