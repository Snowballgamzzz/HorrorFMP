using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPController : MonoBehaviour
{
    public float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] float acceleration = 20f;
    public Transform cameraTransform;
    public bool IsGrounded => controller.isGrounded;
    public bool isPaused = false;

    public float Height
    {
        get => controller.height;
        set => controller.height = value;
    }

    public event Action OnBeforeMove;
    public event Action<bool> OnGroundStateChange;

    internal float movementSpeedMultiplier;

    CharacterController controller;
    internal Vector3 velocity;
    Vector2 look;

    bool wasGrounded;

    //Input System References
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;

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
    }

    private void Update()
    {
        UpdateGround();
        UpdateGravity();
        UpdateLook();
        UpdateMovement();
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
        if (!isPaused)
        {
            var factor = acceleration * Time.deltaTime;
            velocity.x = Mathf.Lerp(velocity.x, input.x, factor);
            velocity.z = Mathf.Lerp(velocity.z, input.z, factor);
        }

        //character controller movement
        controller.Move(velocity * Time.deltaTime);
    }
}
