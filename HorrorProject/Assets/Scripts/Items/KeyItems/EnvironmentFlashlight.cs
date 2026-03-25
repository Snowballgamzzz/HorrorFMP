using UnityEngine;

public class EnvironmentFlashlight : MonoBehaviour, IInteractable
{
    public GameObject environmentFlashlight;
    public GameObject playerFlashlight;

    Flashlight flashLightObject;

    private void Start()
    {
        flashLightObject = playerFlashlight.GetComponent<Flashlight>();
    }

    public void Interact()
    {
        flashLightObject.playerHasFlashlight = true;
        playerFlashlight.SetActive(true);
        Destroy(environmentFlashlight);
    }
}
