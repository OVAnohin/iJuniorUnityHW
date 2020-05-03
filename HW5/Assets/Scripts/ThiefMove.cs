using UnityEngine;

public class ThiefMove : MonoBehaviour
{
  [SerializeField] private float _speed = 0;
  [SerializeField] private ContactFilter2D _filter;

  private Animator _anim;
  private SpriteRenderer _spriteRenderer;
  private Rigidbody2D _rigidbody2D;
  private Vector2 _moveVelocity;
  private readonly RaycastHit2D[] _scanResults = new RaycastHit2D[1];

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
      _anim.SetBool("isMove", false);
    else
      _anim.SetBool("isMove", true);

    if (moveInput.x > 0)
      _spriteRenderer.flipX = false;
    else if (moveInput.x < 0)
      _spriteRenderer.flipX = true;
  }

  private void FixedUpdate()
  {
    int collisionCount;
    if (_spriteRenderer.flipX)
      collisionCount = _rigidbody2D.Cast(transform.right*-1, _filter, _scanResults, 0.1f);
    else
      collisionCount = _rigidbody2D.Cast(transform.right, _filter, _scanResults, 0.1f);

    if (collisionCount == 0)
      _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * Time.fixedDeltaTime);
  }
}