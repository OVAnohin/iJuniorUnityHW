using UnityEngine;
using UnityEngine.Events;

public class Warlock : Enemy
{
  [SerializeField] private Player _player = default;

  public override event UnityAction<Enemy> Dying;
  public override void Init(Player target)
  {
    _target = target;
  }
  public Player GetTarget => _target;

  private void Awake()
  {
    Init(_player);
  }

  protected override void Die()
  {
    _target.AddMoney(Reward);
    Destroy(gameObject);
  }
}
