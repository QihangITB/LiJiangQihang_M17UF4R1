using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, InputControllers.IPlayerActions
{
    public Transform Camera;
    private InputControllers _ic;
    private Vector2 _movementP;
    private Vector2 _cameraP;
    private Rigidbody _rb;

    public float Speed = 5f;

    private void Awake()
    {
        _ic = new InputControllers();
        _ic.Player.SetCallbacks(this);
        _rb = GetComponent<Rigidbody>();
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
        // _movementP.y es como el eje Z pero en 2D
        _rb.velocity = new Vector3(_movementP.x * Speed, _rb.velocity.y, _movementP.y * Speed);

        // Rotar la cámara
        Camera.Rotate(Vector3.up, _cameraP.x);
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

    void InputControllers.IPlayerActions.OnLook(InputAction.CallbackContext context)
    {
        _cameraP = context.ReadValue<Vector2>();
        Debug.Log(_cameraP);
    }
}
