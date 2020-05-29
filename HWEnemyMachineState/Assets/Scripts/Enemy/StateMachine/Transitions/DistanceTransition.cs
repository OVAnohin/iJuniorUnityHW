using System.Linq;
using UnityEngine;

public class DistanceTransition : Transition
{
  [SerializeField] private float _distantionRange;
  [SerializeField] private float _rangeSpread;

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

  private void Start()
  {
    _distantionRange += Random.Range(-_rangeSpread, _rangeSpread);
  }

  private void Update()
  {
    if (Vector2.Distance(transform.position, Target.transform.position) < _distantionRange)
    {
      NeedTransit = true;
      _targetState = (from value in TargetStates
                      where value is GeneralAttackState
                      select value).First();
    }
  }
}
