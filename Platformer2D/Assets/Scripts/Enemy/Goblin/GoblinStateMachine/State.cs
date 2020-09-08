﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
  [SerializeField] private List<Transition> _transitions = null;

  protected Player Target { get; set; }
  protected float Speed { get; set; }

  public void Enter(Player target, float speed)
  {
    if (enabled == false)
    {
      Target = target;
      Speed = speed;
      enabled = true;
      foreach (var transition in _transitions)
      {
        transition.enabled = true;
        transition.Init(target);
      }
    }
  }

  public void Exit()
  {
    if (enabled == true)
    {
      foreach (var transition in _transitions)
        transition.enabled = false;

      enabled = false;
    }
  }

  public State GetNextState()
  {
    foreach (var transition in _transitions)
    {
      if (transition.NeedTransit)
        return transition.TargetState;
    }

    return null;
  }
}
