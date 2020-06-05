using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]

public class JumpState : State
{
  public bool IsJumpEnd { get; private set; }

  private float _elapsedTime;
  private float _endJumpTime = 3;
  private int _lengthJump = 3;
  private Vector3 vector3;
  private Vector3 _startPosition;
  private Vector3 _endPosition;
  private Animator _animator;

  private void Awake()
  {
    _animator = GetComponent<Animator>();
  }

  private void OnEnable()
  {
    IsJumpEnd = false;
    vector3 = new Vector3(0, 0, 0);
    _elapsedTime = 0;
    _startPosition = transform.position;
    _endPosition = _startPosition + new Vector3(_lengthJump, 0, 0);
    _animator.Play("Jump");
  }

  private void Update()
  {
    if (transform.position == _endPosition)
    {
      IsJumpEnd = true;
      return;
    }

    if (!(_elapsedTime > _endJumpTime))
    {
      CalculatingJump();
    }

    _elapsedTime += Time.deltaTime;
  }

  private void CalculatingJump()
  {
    vector3.x = Mathf.Lerp(0f, _endJumpTime, _elapsedTime);
    vector3.y = (-(vector3.x * vector3.x)) + (int)_lengthJump * vector3.x;
    transform.position = _startPosition + vector3;
  }
}
