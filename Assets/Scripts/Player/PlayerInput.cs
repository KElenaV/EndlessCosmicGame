using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _direction;
    private bool _isShoot;

    public Vector2 Direction => _direction;
    //public bool IsShoot => _isShoot;

    public event UnityAction Shoot;

    public void OnMove(InputAction.CallbackContext context) 
        => _direction = context.ReadValue<Vector2>();

    public void OnShoot(InputAction.CallbackContext context)
    {
        _isShoot = context.performed ? true : false;

        if (_isShoot)
            Shoot?.Invoke();
    }
}
