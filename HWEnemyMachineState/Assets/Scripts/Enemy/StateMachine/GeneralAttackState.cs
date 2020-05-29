using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]

public class GeneralAttackState : State
{
  [SerializeField] private float _delay;

  private float _lastAttackTime;
  private Enemy _enemy;
  private Animator _animator;

  private void Awake()
  {
    _enemy = GetComponent<Enemy>();
    _animator = GetComponent<Animator>();
  }

  private void OnEnable()
  {
    _animator.Play("Shoot");
  }

  private void Update()
  {
    if (_lastAttackTime <= 0)
    {
      Attack();
      _lastAttackTime = _delay;
    }

    _lastAttackTime -= Time.deltaTime;
  }

  private void Attack()
  {
    if (_enemy.GetWeapon.IsMelee)
      _enemy.GetWeapon.Slash(_enemy.GetShootPoint);
    else
      _enemy.GetWeapon.Shoot(_enemy.GetShootPoint);
  }
}
