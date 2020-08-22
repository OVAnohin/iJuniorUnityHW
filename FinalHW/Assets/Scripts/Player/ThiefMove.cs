using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ThiefMove : MonoBehaviour
{
  [SerializeField] private float _speed = 0;

  private Animator _anim;
  private SpriteRenderer _spriteRenderer;
  private Rigidbody2D _rigidbody2D;
  private Vector2 _moveVelocity;

  private void Start()
  {
    _anim = GetComponent<Animator>();
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    _moveVelocity = moveInput * _speed;

    if (moveInput.x == 0)
      _anim.SetBool("IsMove", false);
    else
      _anim.SetBool("IsMove", true);

    if (moveInput.x > 0)
      _spriteRenderer.flipX = false;
    else if (moveInput.x < 0)
      _spriteRenderer.flipX = true;
  }

  private void FixedUpdate()
  {
    _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * Time.fixedDeltaTime);
  }
}