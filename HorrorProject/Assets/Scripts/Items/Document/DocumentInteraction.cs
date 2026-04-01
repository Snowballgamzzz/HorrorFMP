using UnityEngine;
using UnityEngine.InputSystem;

public class DocumentInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject document;
    [SerializeField] private GameObject documentInspector;

    public GameObject playerCrosshair;
    public GameObject playerGun;
    public GameObject playerHealth;
    public GameObject playerAmmo;

    FPController FPController;
    public GameObject player;

    private bool isInspectorActive;
    private bool isViewingThisDocument;

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
        playerHealth.SetActive(false);
        playerAmmo.SetActive(false);
        document.SetActive(true);
        FPController.isInspectingDocument = true;
        FPController.mouseSensitivity = 0f;
        isViewingThisDocument = true;
    }

    public void DocumentTextView(InputAction.CallbackContext context)
    {
        if (context.performed && FPController.isInspectingDocument)
        {
            if (isInspectorActive)
            {
                documentInspector.SetActive(false);
                isInspectorActive = false;
            }
            else
            {
                documentInspector.SetActive(true);
                isInspectorActive = true;
            }
        }
    }

    public void DocumentExit(InputAction.CallbackContext context)
    {
        if (context.performed && FPController.isInspectingDocument && isViewingThisDocument)
        {
            documentInspector.SetActive(false);
            document.SetActive(false);
            playerCrosshair.SetActive(true);
            playerGun.SetActive(true);
            playerHealth.SetActive(true);
            playerAmmo.SetActive(true);
            FPController.isInspectingDocument = false;
            FPController.mouseSensitivity = 3f;
            isViewingThisDocument = false;
        }
    }
}
