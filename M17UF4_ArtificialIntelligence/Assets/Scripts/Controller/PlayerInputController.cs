using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, InputControllers.IPlayerActions
{
    private InputControllers _ic;
    private Vector2 _movement;
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
        Vector3 move = new Vector3(_movement.x, 0, _movement.y);

        _rb.velocity = new Vector3(move.x * Speed, _rb.velocity.y, move.z * Speed); // Conservamos la velocidad en Y
    }

    void InputControllers.IPlayerActions.OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _movement = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _movement = Vector2.zero;
        }
    }

    void InputControllers.IPlayerActions.OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
