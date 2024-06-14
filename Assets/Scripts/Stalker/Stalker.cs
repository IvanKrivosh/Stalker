using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stalker : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _minDistance = 1f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {        
        float distance = Vector3.Distance(_target.transform.position, transform.position);

        if (distance > _minDistance)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            Vector3 speed = new Vector3(direction.x * _speed, _rigidbody.velocity.y, direction.z * _speed);

            _rigidbody.velocity = speed;
        }           
    }

}
