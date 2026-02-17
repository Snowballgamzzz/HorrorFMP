using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    public float cameraMoveSpeed = 1.0f;

    private InteractionController raycastedObj;
    private KeyItemController raycastedKey;
    private CodeController raycastedCode;
    public GameObject player;
    FPController cam;

    [SerializeField] private Image crosshair = null;
    [SerializeField] private GameObject crosshairImage;
    private bool isCrosshairActive;

    private bool isDoorWithoutKey;
    private bool isDoorWithKey;
    private bool isSafe;
    private bool isKey;
    public bool correctCode = false;
    public bool playerInteraction = false;
    public bool raycasted;
    public bool cameraZoomed;

    private string interactableTag = "InteractiveObject";
    private string keyInteractableTag = "KeyObject";
    private string keypadInteractableTag = "InteractiveKeypad";

    [Header("Keypad UI")]
    public TMP_Text charHolder;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;
    public GameObject clearButton;
    public GameObject enterButton;
    public float textAmount = 0f;

    [Header("Camera")]
    public GameObject camStartObject;
    public GameObject camEndObject;
    public GameObject playerCamera;
    public Transform cameraStartRotation;
    public Transform cameraEndRotation;

    private void Start()
    {
        cam = player.GetComponent<FPController>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                raycastedObj = hit.collider.gameObject.GetComponentInParent<InteractionController>();
                raycastedKey = hit.collider.gameObject.GetComponentInParent<KeyItemController>();

                if (raycastedObj.typeController == InteractionController.InteractionTypeController.DoorWithNoKey && !isDoorWithoutKey)
                {
                    CrosshairChange(true);
                    isDoorWithoutKey = true;
                }

                if (raycastedObj.typeController == InteractionController.InteractionTypeController.DoorWithKey && !isDoorWithKey)
                {
                    CrosshairChange(true);
                    isDoorWithKey = true;
                }

                isCrosshairActive = true;
            }

            if (hit.collider.CompareTag(keyInteractableTag))
            {
                raycastedKey = hit.collider.gameObject.GetComponent<KeyItemController>();

                if (!isKey)
                {
                    CrosshairChange(true);
                    isKey = true;
                }

                isCrosshairActive = true;
                isKey = false;
            }

            if (hit.collider.CompareTag(keypadInteractableTag))
            {
                raycastedCode = hit.collider.gameObject.GetComponent<CodeController>();

                if (!isSafe)
                {
                    CrosshairChange(true);
                    isSafe = true;
                }

                isCrosshairActive = true;
                //isSafe = false;
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
            }
        }

        if (textAmount > 3)
        {
            playerInteraction = false;
        }
        else
        {
            playerInteraction = true;
        }
    }

    public void ToggleDoor(InputAction.CallbackContext context)
    {
        if (context.performed && isCrosshairActive && isDoorWithoutKey)
        {
            raycastedObj.PlayAnimation();
            isDoorWithoutKey = false;
        }

        if (context.performed && isCrosshairActive && isDoorWithKey)
        {
            raycastedKey.ObjectInteraction();
            isDoorWithKey = false;
        }

        if (context.performed && isCrosshairActive && isKey)
        {
            raycastedKey.ObjectInteraction();
            isKey = false;
        }

        if (context.performed && isCrosshairActive && isSafe)
        {
            crosshairImage.SetActive(false);
            isSafe = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam.mouseSensitivity = 0f;
            cam.isAtKeypad = true;
            playerInteraction = true;
            raycasted = true;
            cameraZoomed = true;
            cam.isAtKeypad = true;
            CameraZoom();
        }
    }

    public void ToggleEscape(InputAction.CallbackContext context)
    {
        if (context.performed && cam.isAtKeypad)
        {
            crosshairImage.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam.mouseSensitivity = 3f;
            cam.isAtKeypad = false;
            charHolder.text = null;
            playerInteraction = false;
            raycasted = false;
            cameraZoomed = false;
            CameraZoom();
            textAmount = 0f;
        }
    }

    void CrosshairChange(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }

    void CameraZoom()
    {
        if (cameraZoomed == true)
        {
            playerCamera.transform.rotation = camEndObject.transform.rotation;
            playerCamera.transform.position = camEndObject.transform.position;
            playerCamera.transform.SetParent(camEndObject.transform);
        }

        if (cameraZoomed == false)
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
            raycastedCode.PlayAnim();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cam.isAtKeypad = false;
            cam.mouseSensitivity = 3f;
            playerInteraction = false;
            crosshairImage.SetActive(true);
            correctCode = true;
            cameraZoomed = false;
            playerCamera.transform.rotation = camStartObject.transform.rotation;
            playerCamera.transform.position = camStartObject.transform.position;
            playerCamera.transform.SetParent(camStartObject.transform);
        }
        else
        {
            charHolder.text = "Incorrect";
            playerInteraction = false;
            StartCoroutine(HaltInteraction());
            textAmount = 0f;
        }
    }

    private IEnumerator HaltInteraction()
    {
        yield return new WaitForSeconds(1f);
        charHolder.text = null;
        playerInteraction = true;
    }
}
