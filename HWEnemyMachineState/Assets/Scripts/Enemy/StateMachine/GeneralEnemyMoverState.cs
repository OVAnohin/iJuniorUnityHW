using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
public class GeneralEnemyMoverState : State
{
  private float _speed;
  private Animator _animator;
  private void Awake()
  {
    _speed = GetComponent<Enemy>().GetSpeed;
    _animator = GetComponent<Animator>();
  }

  private void OnEnable()
  {
    _animator.Play("Run");
  }



  private void Update()
  {
    transform.Translate(Vector2.right * _speed * Time.deltaTime);
  }
}
