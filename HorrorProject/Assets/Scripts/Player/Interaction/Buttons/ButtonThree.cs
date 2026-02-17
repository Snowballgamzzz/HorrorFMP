using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonThree : MonoBehaviour
{
    Interaction interactor;
    public GameObject playerCam;

    public bool isPlayerMouseOverButtonThree = false;

    private void Start()
    {
        interactor = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        isPlayerMouseOverButtonThree = true;
    }

    private void OnMouseExit()
    {
        isPlayerMouseOverButtonThree = false;
    }

    public void ButtonThreePress(InputAction.CallbackContext context)
    {
        if (context.performed && isPlayerMouseOverButtonThree && interactor.playerInteraction)
        {
            interactor.b3();
            interactor.textAmount += 1;
        }
    }
}
