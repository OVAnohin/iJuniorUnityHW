using System.Linq;
using UnityEngine;

[RequireComponent(typeof(JumpState))]

public class JumpTransition : Transition
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
  }

  private void Update()
  {
    if (GetComponent<JumpState>().IsJumpEnd)
    {
      NeedTransit = true;
      _targetState = (from value in TargetStates
                      where value is MoveState
                      select value).First();
    }
  }
}
