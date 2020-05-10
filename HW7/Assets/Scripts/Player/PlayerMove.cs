using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{

  [SerializeField] private float _speed = 0;
  [SerializeField] private Transform _groundCheck = null;
  [SerializeField] private float _checkRadius = 0.2f;
  [SerializeField] private float _jumpForce = 10f;
  [SerializeField] private LayerMask _whatIsGround = new LayerMask();

  private Animator _anim;
  private SpriteRenderer _spriteRenderer;
  private Rigidbody2D _rigidbody2D;
  private float _moveVelocity;
  private bool _isGrounded;

  private void Start()
  {
    _anim = GetComponent<Animator>();
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    
    float moveInput = Input.GetAxisRaw("Horizontal");
    _moveVelocity = moveInput * _speed;
    _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);

    if (moveInput == 0)
      _anim.SetBool("isMove", false);
    else
      _anim.SetBool("isMove", true);

    if (moveInput > 0)
      _spriteRenderer.flipX = false;
    else if (moveInput < 0)
      _spriteRenderer.flipX = true;

    if (_isGrounded)
    {
      _rigidbody2D.velocity = new Vector2(_moveVelocity, _rigidbody2D.velocity.y);
    }

    if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && _isGrounded == true)
    {
      _anim.SetTrigger("Jump");
      _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }
  }
}
