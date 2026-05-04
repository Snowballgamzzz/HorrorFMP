using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{

    public event Action OnBeforeMove;
    public event Action<bool> OnGroundStateChange;

    [Header("Floats")]
    public float mouseSensitivity = 3f;
    public float movementSpeed = 5f;
    public float tutorialSeconds;

    [SerializeField] float mass = 1f;
    [SerializeField] float acceleration = 20f;
    [SerializeField] float walkStepInterval = 0.5f;
    [SerializeField] float sprintStepInterval = 0.3f;
    [SerializeField] float velocityThreshold = 2.0f;

    private float nextStepTime;

    public float Height
    {
        get => controller.height;
        set => controller.height = value;
    }

    internal float movementSpeedMultiplier;

    [Header("Transform")]
    public Transform cameraTransform;

    [Header("Boolean")]
    public bool IsGrounded => controller.isGrounded;
    public bool isPaused = false;
    public bool isAtKeypad = false;
    public bool isAtPC = false;
    public bool isInspectingDocument = false;
    bool wasGrounded;
    public bool isMoving;

    [Header("Vector")]
    internal Vector3 velocity;
    Vector2 look;

    [Header("References")]
    CharacterController controller;

    //Input System References
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;

    [Header("GameObject")]
    public GameObject playerWalkingTutorialUI;

    [Header("Audio")]
    [SerializeField] private AudioSource footstepSource;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        lookAction = playerInput.actions["look"];
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerWalkingTutorialUI.SetActive(true);
    }

    private void Update()
    {
        UpdateGround();
        UpdateGravity();
        UpdateLook();
        UpdateMovement();
        HandleFootsteps();
    }

    void UpdateGround()
    {
        if (wasGrounded != IsGrounded)
        {
            OnGroundStateChange?.Invoke(IsGrounded);
            wasGrounded = IsGrounded;
        }
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
    }

    void UpdateLook()
    {
        //Looking
        var lookInput = lookAction.ReadValue<Vector2>();
        look.x += lookInput.x * mouseSensitivity;
        look.y += lookInput.y * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    Vector3 GetMovementInput()
    {
        //Movement
        var moveInput = moveAction.ReadValue<Vector2>();

        var input = new Vector3();
        input += transform.forward * moveInput.y;
        input += transform.right * moveInput.x;
        input = Vector3.ClampMagnitude(input, 1f);

        input *= movementSpeed * movementSpeedMultiplier;

        return input;
    }

    void UpdateMovement()
    {
        movementSpeedMultiplier = 1f;
        OnBeforeMove?.Invoke();

        var input = GetMovementInput();

        //Movement Speed
        if (!isPaused && !isAtKeypad && !isAtPC && !isInspectingDocument)
        {
            var factor = acceleration * Time.deltaTime;
            velocity.x = Mathf.Lerp(velocity.x, input.x, factor);
            velocity.z = Mathf.Lerp(velocity.z, input.z, factor);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //character controller movement
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleFootsteps()
    {
        float currentStepInterval = (Input.GetKey(KeyCode.LeftShift) ? sprintStepInterval : walkStepInterval);

        if (IsGrounded && isMoving && Time.time > nextStepTime && controller.velocity.magnitude > velocityThreshold)
        {
            PlayFootstepSounds();
            nextStepTime = Time.time + currentStepInterval;
        }
        else
        {
            StopFootstepSounds();
        }
    }

    void PlayFootstepSounds()
    {
        footstepSource.Play();
    }

    void StopFootstepSounds()
    {
        footstepSource.Stop();
    }

}
