using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonZero : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonZero = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonZero = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonZero = false;
    }

    public void ButtonZeroPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonZero && interactor.playerInteraction)
        {
            interactor.b0();
            interactor.textAmount += 1;
        }
    }
}
