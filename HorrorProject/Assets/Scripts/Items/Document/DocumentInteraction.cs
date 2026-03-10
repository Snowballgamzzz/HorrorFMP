using UnityEngine;
using UnityEngine.InputSystem;

public class DocumentInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject document;
    [SerializeField] private GameObject documentInspector;

    public GameObject playerCrosshair;
    public GameObject playerGun;

    FPController FPController;
    public GameObject player;

    private bool isInspectorActive;

    void Start()
    {
        FPController = player.GetComponent<FPController>();
        document.SetActive(false);
        playerCrosshair.SetActive(true);
    }

    public void Interact()
    {
        playerCrosshair.SetActive(false);
        playerGun.SetActive(false);
        document.SetActive(true);
        FPController.isInspectingDocument = true;
        FPController.mouseSensitivity = 0f;
    }

    public void DocumentTextView(InputAction.CallbackContext context)
    {
        if (context.performed && FPController.isInspectingDocument)
        {
            if (isInspectorActive)
            {
                documentInspector.SetActive(false);
            }
            else
            {
                documentInspector.SetActive(true);
            }
        }
    }

    public void DocumentExit(InputAction.CallbackContext context)
    {
        if (context.performed && FPController.isInspectingDocument)
        {
            documentInspector.SetActive(false);
            document.SetActive(false);
            playerCrosshair.SetActive(true);
            playerGun.SetActive(true);
            FPController.isInspectingDocument = false;
            FPController.mouseSensitivity = 3f;
        }
    }
}
