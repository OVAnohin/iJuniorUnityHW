using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GoblinStateMachine))]

public class Goblin : Enemy
{
  [SerializeField] private float _speed = 0;

  public override event UnityAction<Enemy> Dying;
  public Player GetTarget => _target;
  public float GetSpeed => _speed;

  public override void Init(Player player)
  {
    _target = player;
  }

  protected override void Die()
  {
    _target.AddMoney(Reward);
    GetComponent<GoblinStateMachine>().ResetOnDie();
    gameObject.SetActive(false);
  }
}
