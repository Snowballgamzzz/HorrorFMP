using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonOne : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonOne = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonOne = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonOne = false;
    }

    public void ButtonOnePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonOne && interactor.playerInteraction)
        {
            interactor.b1();
            interactor.textAmount += 1;
        }
    }
}
