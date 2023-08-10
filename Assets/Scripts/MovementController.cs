using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Animator _animator;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement.normalized * (moveSpeed * Time.fixedDeltaTime));
    }
}
