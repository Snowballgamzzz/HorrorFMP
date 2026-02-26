using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SafeController : MonoBehaviour, IInteractable
{
    [Header("References")]
    public GameObject player;
    public GameObject gun;
    FPController cam;
    private Animator safeAnim;

    [Header("Camera")]
    public GameObject camStartObject;
    public GameObject camEndObject;
    public GameObject playerCamera;
    public Transform cameraStartRotation;
    public Transform cameraEndRotation;

    [Header("PlayerUI")]
    public GameObject crosshairImage;

    [Header("Booleans")]
    public bool correctCode = false;
    public bool playerCanInteract = false;
    public bool cameraZoomed;
    private bool safeOpen = false;

    [Header("Keypad Buttons")]
    public TMP_Text charHolder;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject buttonFour;
    public GameObject buttonFive;
    public GameObject buttonSix;
    public GameObject buttonSeven;
    public GameObject buttonEight;
    public GameObject buttonNine;
    public GameObject buttonZero;
    public GameObject clearButton;
    public GameObject enterButton;
    public float textAmount = 0f;

    public void Start()
    {
        cam = player.GetComponent<FPController>();
        safeAnim = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        crosshairImage.SetActive(false);
        gun.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam.mouseSensitivity = 0f;
        cam.isAtKeypad = true;
        playerCanInteract = true;
        cameraZoomed = true;
        CameraZoom();
    }

    public void ToggleEscape(InputAction.CallbackContext context)
    {
        if (context.performed && cam.isAtKeypad)
        {
            crosshairImage.SetActive(true);
            gun.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.mouseSensitivity = 3f;
            cam.isAtKeypad = false;
            charHolder.text = null;
            playerCanInteract = false;
            cameraZoomed = false;
            CameraZoom();
            textAmount = 0f;
        }
    }

    private void CameraZoom()
    {
        if (cameraZoomed == true)
        {
            playerCamera.transform.rotation = camEndObject.transform.rotation;
            playerCamera.transform.position = camEndObject.transform.position;
            playerCamera.transform.SetParent(camEndObject.transform);
        }
        else if (cameraZoomed == false)
        {
            playerCamera.transform.rotation = camStartObject.transform.rotation;
            playerCamera.transform.position = camStartObject.transform.position;
            playerCamera.transform.SetParent(camStartObject.transform);
        }
    }

    public void b1()
    {
        charHolder.text = charHolder.text + "1";
    }

    public void b2()
    {
        charHolder.text = charHolder.text + "2";
    }

    public void b3()
    {
        charHolder.text = charHolder.text + "3";
    }

    public void b4()
    {
        charHolder.text = charHolder.text + "4";
    }

    public void b5()
    {
        charHolder.text = charHolder.text + "5";
    }

    public void b6()
    {
        charHolder.text = charHolder.text + "6";
    }

    public void b7()
    {
        charHolder.text = charHolder.text + "7";
    }

    public void b8()
    {
        charHolder.text = charHolder.text + "8";
    }

    public void b9()
    {
        charHolder.text = charHolder.text + "9";
    }

    public void b0()
    {
        charHolder.text = charHolder.text + "0";
    }

    public void clearEvent()
    {
        charHolder.text = null;
    }

    public void deleteEvent()
    {
        charHolder.text = charHolder.text.Substring(0, charHolder.text.Length - 1);
    }

    public void enterEvent()
    {
        if (charHolder.text == "2610")
        {
            if (!safeOpen)
            {
                safeAnim.Play("SafeOpen", 0, 0.0f);
                safeOpen = true;
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cam.isAtKeypad = false;
            cam.mouseSensitivity = 3f;
            playerCanInteract = false;
            crosshairImage.SetActive(true);
            gun.SetActive(true);
            correctCode = true;
            cameraZoomed = false;
            CameraZoom();
        }
        else
        {
            charHolder.text = "Incorrect";
            playerCanInteract = false;
            StartCoroutine(HaltInteraction());
            textAmount = 0f;
        }
    }

    private IEnumerator HaltInteraction()
    {
        yield return new WaitForSeconds(1f);
        charHolder.text = null;
        playerCanInteract = true;
    }
}
