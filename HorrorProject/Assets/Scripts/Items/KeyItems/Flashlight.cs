using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    public GameObject playerflashlight;
    public GameObject tutorialUI;
    public bool isFlashlightOn;
    public bool playerHasFlashlight;

    FlashlightTutorial tutorial;

    private void Start()
    {
        playerHasFlashlight = true;
        isFlashlightOn = true;
        tutorial = tutorialUI.GetComponent<FlashlightTutorial>();
        StartCoroutine(tutorial.showFlashLightTutorial());
    }

    public void FlashlightToggle(InputAction.CallbackContext context)
    {
        if (isFlashlightOn && playerHasFlashlight)
        {
            playerflashlight.SetActive(false);
            isFlashlightOn = false;
        }
        else if (!isFlashlightOn && playerHasFlashlight)
        {
            playerflashlight.SetActive(true);
            isFlashlightOn = true;
        }
    }
}
