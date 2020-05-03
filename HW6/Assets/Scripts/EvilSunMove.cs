using UnityEngine;

public class EvilSunMove : MonoBehaviour
{
  [SerializeField] private float _speed = 0;
  [SerializeField] private Transform _groundCheck = null;
  [SerializeField] private float _checkRadius = 0.5f;
  [SerializeField] private LayerMask _whatIsGround = new LayerMask();

  private Rigidbody2D _rigidbody2D;
  private System.Random rand = new System.Random();
  private int _direction;
  private Collider2D _isGrounded;

  private void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _direction = rand.Next(2) == 1 ? 1 : -1;
  }

  private void FixedUpdate()
  {
    _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);

    if (_isGrounded)
    {
      Vector2 moveInput = new Vector2(_direction, 0);
      Vector2 _moveVelocity = moveInput * _speed;
      _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * Time.fixedDeltaTime);
    }
  }
}
