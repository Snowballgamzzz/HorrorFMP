using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PCController : MonoBehaviour, IInteractable
{
    [Header("Reference")]
    public GameObject player;
    FPController cam;

    [Header("PlayerUI")]
    public GameObject crosshair;

    [Header("PC UI")]
    public GameObject logInScreen;
    public GameObject homeScreen;
    public GameObject lockDownScreen;
    public GameObject wrongUsernameOrPassword;
    public Text usernameText;
    public Text passwordText;
    public Text lockDownText;

    [Header("Strings")]
    public string username;
    public string password;
    public string lockDownCode;

    [Header("Boolean Check")]
    bool isPlayerAtlockDownScreen;
    bool isPlayerAtHomeScreen;

    private void Start()
    {
        cam = player.gameObject.GetComponent<FPController>();
    }

    public void Interact()
    {
        logInScreen.SetActive(true);
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam.mouseSensitivity = 0f;
        cam.isAtPC = true;
    }

    public void LogInCheck()
    {
        if (usernameText.text == username && passwordText.text == password)
        {
            homeScreen.SetActive(true);
            logInScreen.SetActive(false);
        }
        else
        {
            wrongUsernameOrPassword.SetActive(true);
        }
    }

    public void LockDownCheck()
    {
        if (lockDownText.text == lockDownCode)
        {
            Debug.Log("Log Down Lifted");
        }
    }


    public void lockDownScreenSite()
    {
        if (isPlayerAtHomeScreen)
        {
            homeScreen.SetActive(false);
        }

        lockDownScreen.SetActive(true);
        isPlayerAtlockDownScreen = true;
        isPlayerAtHomeScreen = false;
    }

    public void homeScreenSite()
    {
        if (isPlayerAtlockDownScreen)
        {
            lockDownScreen.SetActive(false);
        }

        homeScreen.SetActive(true);
        isPlayerAtHomeScreen = true;
        isPlayerAtlockDownScreen = false;
    }

    public void ToggleEscape(InputAction.CallbackContext context)
    {
        if (context.performed && cam.isAtKeypad)
        {
            crosshair.SetActive(true);

            if (isPlayerAtHomeScreen)
            {
                homeScreen.SetActive(false);
                isPlayerAtHomeScreen = false;
            }
            else if (isPlayerAtlockDownScreen)
            {
                lockDownScreen.SetActive(false);
                isPlayerAtlockDownScreen = false;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.mouseSensitivity = 3f;
            cam.isAtPC = false;

        }
    }
}
