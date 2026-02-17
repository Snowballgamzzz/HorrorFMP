using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClear : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonClear = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonClear = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonClear = false;
    }

    public void ButtonClearPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonClear)
        {
            interactor.clearEvent();
            interactor.textAmount = 0;
            interactor.playerInteraction = true;
        }
    }
}
