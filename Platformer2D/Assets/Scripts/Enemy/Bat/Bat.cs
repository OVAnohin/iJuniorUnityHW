using UnityEngine.Events;

public class Bat : Enemy
{
  public override event UnityAction<Enemy> Dying;
  public Player GetTarget => _target;

  public override void Init(Player player)
  {
    _target = player;
  }

  protected override void Die()
  {
    _target.AddMoney(Reward);

    gameObject.SetActive(false);
  }
}
