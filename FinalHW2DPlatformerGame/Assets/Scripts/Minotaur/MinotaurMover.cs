using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MinotaurMover : MonoBehaviour
{
  [SerializeField] private float _speed = 0;
  [SerializeField] private Transform _groundCheck = null;
  [SerializeField] private Transform _frontsCheck = null;
  [SerializeField] private LayerMask _whatIsGground = default;
  [SerializeField] private float _jumpForce = 0;
  [SerializeField] private float _checkRadius = 0.5f;
  [SerializeField] private float _wallSlidingSpeed = 0;
  [SerializeField] private float _xWallForce = 0;
  [SerializeField] private float _yWallForce = 0;
  [SerializeField] private float _wallJumpTime = 0;

  private Rigidbody2D _rigidbody2D;
  private bool _facingRight = true;
  private bool _isGrounded;
  private bool _isTouchingFronts;
  private bool _wallSliding;
  private bool _wallJumping;

  private void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    float input = Input.GetAxisRaw("Horizontal");
    _rigidbody2D.velocity = new Vector2(input * _speed, _rigidbody2D.velocity.y);

    if (input > 0 && _facingRight == false)
      Flip();
    else if (input < 0 && _facingRight == true)
      Flip();

    _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGground);
    if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && _isGrounded == true)
      _rigidbody2D.velocity = Vector2.up * _jumpForce;

    _isTouchingFronts = Physics2D.OverlapCircle(_frontsCheck.position, _checkRadius, _whatIsGground);
    if (_isTouchingFronts == true && _isGrounded == false && input != 0)
      _wallSliding = true;
    else
      _wallSliding = false;

    if (_wallSliding)
      _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSlidingSpeed, float.MaxValue));

    if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && _wallSliding == true)
    {
      _wallJumping = true;
      StartCoroutine(SetWallJumpingToFalse());
    }

    if (_wallJumping)
    {
      _rigidbody2D.velocity = new Vector2(_xWallForce * -input, _yWallForce);
    }

  }

  private void Flip()
  {
    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    _facingRight = !_facingRight;
  }

  private IEnumerator SetWallJumpingToFalse()
  {
    float elapsedTime = _wallJumpTime;
    while (elapsedTime > 0)
    {
      elapsedTime -= Time.deltaTime;
      yield return null;
    }

    _wallJumping = false;
  }
}
