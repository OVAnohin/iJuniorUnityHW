using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
  [SerializeField] protected int Health;
  [SerializeField] protected int Reward;
  [SerializeField] protected float Speed;
  [SerializeField] private Weapon _weapon;
  [SerializeField] private Transform _shootPoing;

  public UnityAction<int> EnemyDied;
  public float GetSpeed
  {
    get
    { return Speed; }
  }
  public Transform GetShootPoint
  {
    get
    { return _shootPoing; }
  }
  public Weapon GetWeapon
  {
    get
    { return _weapon; }
    protected set { }

  }

  public void TakeDamage(int damage)
  {
    Health -= damage;

    if (Health <= 0)
      Die();
  }

  private void Die()
  {
    if (EnemyDied != null)
      EnemyDied(Reward);

    Destroy(gameObject);
  }
}
