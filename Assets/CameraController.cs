using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float fastMoveSpeed = 20f;
    [SerializeField] private float moveSmoothness = 10f;

    [Header("Rotation Settings")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float verticalRotationLimit = 89f;

    private Vector2 moveInput;
    private Vector2 mouseDelta;
    private bool isRotating;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
        
        Vector3 euler = transform.eulerAngles;
        rotationX = euler.x;
        rotationY = euler.y;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector3 inputDirection = Vector3.zero;

        if (keyboard.wKey.isPressed) inputDirection.z += 1f;
        if (keyboard.sKey.isPressed) inputDirection.z -= 1f;
        if (keyboard.aKey.isPressed) inputDirection.x -= 1f;
        if (keyboard.dKey.isPressed) inputDirection.x += 1f;
        if (keyboard.qKey.isPressed) inputDirection.y -= 1f;
        if (keyboard.eKey.isPressed) inputDirection.y += 1f;

        float currentSpeed = keyboard.leftShiftKey.isPressed ? fastMoveSpeed : moveSpeed;

        Vector3 moveDirection = transform.right * inputDirection.x + 
                                transform.up * inputDirection.y + 
                                transform.forward * inputDirection.z;

        targetPosition += moveDirection.normalized * currentSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSmoothness);
    }

    private void HandleRotation()
    {
        Mouse mouse = Mouse.current;
        if (mouse == null) return;

        if (mouse.rightButton.isPressed)
        {
            if (!isRotating)
            {
                isRotating = true;
            }

            Vector2 delta = mouse.delta.ReadValue();
            
            rotationY += delta.x * mouseSensitivity;
            rotationX -= delta.y * mouseSensitivity;
            
            rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
        else
        {
            if (isRotating)
            {
                isRotating = false;
            }
        }
    }
}
