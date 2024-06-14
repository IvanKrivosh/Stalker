using GameEvent;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] 
    private Vector3Event _changedDirection;

    private InputPlayer _inputPlayer;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _inputPlayer = new InputPlayer();

        _inputPlayer.Player.Move.performed += OnMove;
        _inputPlayer.Player.Move.canceled += OnMove;
    }

    private void OnDestroy()
    {
        _inputPlayer.Player.Move.performed -= OnMove;
        _inputPlayer.Player.Move.canceled -= OnMove;
    }

    private void OnEnable()
    {
        _inputPlayer.Enable();
    }

    private void OnDisable()
    {
        _inputPlayer.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        ChangeDirection(ref _moveDirection, context);
    }

    private void ChangeDirection(ref Vector3 direction, InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        direction = new Vector3(value.x, value.y, 0);

        _changedDirection.Invoke(_moveDirection);
    }

}
