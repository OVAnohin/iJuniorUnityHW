using System.Linq;
using UnityEngine;

public class PlayerDieTransition : Transition
{
  private State _targetState = null;

  public override State TargetState
  {
    get
    {
      return _targetState;
    }
  }

  private void OnEnable()
  {
    NeedTransit = false;
    if (Target != null)
      Target.PlayerDied += OnPlayerDied;
  }

  private void OnDisable()
  {
    if (Target != null)
      Target.PlayerDied -= OnPlayerDied;
  }

  private void OnPlayerDied()
  {
    NeedTransit = true;
    _targetState = (from value in TargetStates
                    where value is IdleState
                    select value).First();
  }
}
