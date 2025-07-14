using UnityEngine.InputSystem;
using UnityEngine;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerControllerX : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float maxTiltAngle = 30f;
    public float propellerSpinSpeed = 1000f;

    [Header("References")]
    public GameObject propeller;
    public InputActionAsset inputActions; // Drag your asset here in Inspector

    // Input
    private InputAction moveAction;
    private Vector2 moveInput;

    private void Awake()
    {
        // Initialize input
        if (inputActions == null)
        {
            Debug.LogError("Assign Input Action Asset in Inspector!");
            return;
        }

        moveAction = inputActions.FindAction("Move");
        if (moveAction == null)
        {
            Debug.LogError("'Move' action not found in Input Actions!");
        }
    }

    private void OnEnable()
    {
        if (moveAction != null) moveAction.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.Disable();
    }

    void FixedUpdate()
    {
        // Get input from Input System
        moveInput = moveAction.ReadValue<Vector2>();

        // Calculate rotation
        Vector3 rotation = new Vector3(
            -moveInput.y * rotationSpeed, // Pitch (up/down)
            0f,                          // No yaw
            -moveInput.x * rotationSpeed // Roll (left/right)
        );

        // Apply rotation
        transform.Rotate(rotation * Time.fixedDeltaTime);

        // Clamp rotation
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = ClampAngle(currentRotation.x, -maxTiltAngle, maxTiltAngle);
        currentRotation.z = ClampAngle(currentRotation.z, -maxTiltAngle, maxTiltAngle);
        currentRotation.y = 0f; // Prevent any yaw rotation
        transform.localEulerAngles = currentRotation;

        // Calculate movement based on tilt
        float pitch = -ClampAngle(currentRotation.x);
        float roll = -ClampAngle(currentRotation.z);

        // Convert tilt to movement
        float verticalMovement = (pitch / maxTiltAngle) * speed;
        float horizontalMovement = (roll / maxTiltAngle) * speed;

        // Apply movement
        Vector3 newPosition = transform.position;
        newPosition.y += verticalMovement * Time.fixedDeltaTime;
        newPosition.x += horizontalMovement * Time.fixedDeltaTime;
        newPosition.z = 0f; // Lock Z position
        transform.position = newPosition;

        // Spin propeller
        propeller.transform.Rotate(Vector3.forward * propellerSpinSpeed * Time.fixedDeltaTime);
    }

    private float ClampAngle(float angle, float min = -180.0f, float max = 180.0f)
    {
        if (angle > 180.0f) angle -= 360.0f;
        if (angle < -180.0f) angle += 360.0f;
        return Mathf.Clamp(angle, min, max);
    }
}