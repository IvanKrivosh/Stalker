using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _gravityFactor = 1.5f;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private Vector3 _verticalVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();        
    }

    private void Update()
    {
        Move();        
    }

    public void ChangeMoveDirection(Vector3 direction)
    {
        Vector3 forward = gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;

        _moveDirection = forward * direction.y * _speed + right * direction.x * _speed;
    }

    private void Move()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = Vector3.down;
            _characterController.Move((_moveDirection + _verticalVelocity) * Time.deltaTime);            
        }
        else
        {
            Vector3 horizontalVelocity = _characterController.velocity;
            horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
            _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
        }
    }

}
