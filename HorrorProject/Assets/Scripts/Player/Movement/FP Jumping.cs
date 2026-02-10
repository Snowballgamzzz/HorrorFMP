using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FPController))]
public class FPJumping : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float jumpPressBufferTime = 0.05f;
    [SerializeField] float jumpGroundGraceTime = 0.2f;

    FPController controller;
    FPCrouching crouchController;
    PlayerInput playerInput;
    InputAction jumpAction;

    public bool tryingToJump;
    float lastJumpPressTime;
    float lastGroundedTime;
    int jumps;

    void Awake()
    {
        controller = GetComponent<FPController>();
        crouchController = GetComponent<FPCrouching>();
    }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["jump"];
        jumpAction.performed += OnJump;
    }

    void OnEnable()
    {
        controller.OnBeforeMove += OnBeforeMove;
        controller.OnGroundStateChange += OnGroundStateChange;
        if (playerInput != null)
        {
            jumpAction.performed += OnJump;
        }
    }

    void OnDisable()
    {
        controller.OnBeforeMove -= OnBeforeMove;
        controller.OnGroundStateChange -= OnGroundStateChange;
        if (playerInput != null)
        {
            jumpAction.performed -= OnJump;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        tryingToJump = true;
        lastJumpPressTime = Time.time;
    }

    void OnBeforeMove()
    {
        if (controller.IsGrounded) jumps = 0;

        bool wasTryingToJump = Time.time - lastJumpPressTime < jumpPressBufferTime;
        bool wasGrounded = Time.time - lastGroundedTime < jumpGroundGraceTime;

        bool isOrWasTryingToJump = tryingToJump || (wasTryingToJump && controller.IsGrounded);
        bool isOrWasGrounded = controller.IsGrounded || wasGrounded;

        bool jumpAllowed = jumps < 1;

        bool canJump = jumpAllowed && isOrWasTryingToJump && isOrWasGrounded && !crouchController.IsCrouching && !controller.isPaused && !controller.isAtKeypad;

        if (canJump)
        {
            controller.velocity.y += jumpSpeed;
            jumps++;
        }
        tryingToJump = false;
    }

    void OnGroundStateChange(bool isGrounded)
    {
        if (!isGrounded) lastGroundedTime = Time.time;
    }
}
