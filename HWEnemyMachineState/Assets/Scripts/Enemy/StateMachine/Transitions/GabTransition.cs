using System.Linq;
using UnityEngine;

public class GabTransition : Transition
{
  [SerializeField] private Transform _gabCheck;
  [SerializeField] private float _distanceCheck;
  [SerializeField] private LayerMask _whatsIsGround;

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
    bool isGap = Physics2D.Raycast(_gabCheck.position, Vector2.down, _distanceCheck, _whatsIsGround);
    if (!isGap)
    {
      NeedTransit = true;
      _targetState = (from value in TargetStates
                      where value is GeneralJumpState
                      select value).First();
    }
  }
}
