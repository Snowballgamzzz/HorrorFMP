using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonEight : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonEight = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonEight = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonEight = false;
    }

    public void ButtonEightPress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonEight && interactor.playerInteraction)
        {
            interactor.b8();
            interactor.textAmount += 1;
        }
    }
}
