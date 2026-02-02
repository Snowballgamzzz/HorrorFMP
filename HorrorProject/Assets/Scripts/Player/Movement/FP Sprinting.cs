using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FPController))]
public class FPSprinting : MonoBehaviour
{
    [SerializeField] float speedMultipler = 2f;

    FPController controller;
    
    PlayerInput playerInput;
    InputAction sprintAction;

    void Awake()
    {
        controller = GetComponent<FPController>();
        playerInput = GetComponent<PlayerInput>();
        sprintAction = playerInput.actions["sprint"];
    }

    void OnEnable() => controller.OnBeforeMove += OnBeforeMove;
    void OnDisable() => controller.OnBeforeMove -= OnBeforeMove;

    void OnBeforeMove()
    {
        var sprintInput = sprintAction.ReadValue<float>();

        if (sprintInput == 0) return;

        var forwardMovementFactor = Mathf.Clamp01(Vector3.Dot(playerInput.transform.forward, controller.velocity.normalized));
        var multiplier = Mathf.Lerp(1f, speedMultipler, forwardMovementFactor);

        controller.movementSpeedMultiplier *= multiplier;
    }
}
