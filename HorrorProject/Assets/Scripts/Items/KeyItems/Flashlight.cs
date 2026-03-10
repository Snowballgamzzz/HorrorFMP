using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public bool isFlashlightOn;

    public void FlashlightToggle(InputAction.CallbackContext context)
    {
        if (isFlashlightOn)
        {
            flashlight.SetActive(false);
        }
        else
        {
            flashlight.SetActive(true);
        }
    }
}
