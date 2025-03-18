using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, InputControllers.IPlayerActions
{
    private InputControllers _ic;
    private Vector2 _movementP;
    private Rigidbody _rb;

    private float _rotationX = 0f;

    public Transform Camera;
    public float MovementSpeed = 5f;
    public float CameraSpeed = 300f;

    private void Awake()
    {
        _ic = new InputControllers();
        _ic.Player.SetCallbacks(this);
        _rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        _ic.Player.Enable();
    }

    private void OnDisable()
    {
        _ic.Player.Disable();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        MoveCameraWithMouse();
    }

    private void MovePlayer()
    {
        Vector3 forward = Camera.forward;
        Vector3 right = Camera.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * _movementP.y + right * _movementP.x).normalized;

        _rb.velocity = new Vector3(movement.x * MovementSpeed, _rb.velocity.y, movement.z * MovementSpeed);
    }

    private void MoveCameraWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * CameraSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * CameraSpeed * Time.deltaTime;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        Camera.localEulerAngles = Vector3.right * _rotationX;

        transform.Rotate(Vector3.up * mouseX);
    }

    void InputControllers.IPlayerActions.OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _movementP = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _movementP = Vector2.zero;
        }
    }
}
