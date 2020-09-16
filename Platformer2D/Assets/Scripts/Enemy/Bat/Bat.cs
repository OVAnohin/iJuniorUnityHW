using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bat : Enemy
{
  public override event UnityAction Dying;
  public Player GetTarget => Target;

  public override void Init(Player player)
  {
    Target = player;
  }

  protected override void Die()
  {
    Target.AddMoney(Reward);
    Dying?.Invoke();
    gameObject.SetActive(false);
  }
}
