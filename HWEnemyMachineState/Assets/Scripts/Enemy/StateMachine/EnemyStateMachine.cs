using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
  [SerializeField] private State _firstState; 
  
  [SerializeField] private Player _target; 
  //private Player _target; 
  private State _currentState; 

  public State Current 
  {
    get { return _currentState; }
  }

  private void Start()
  {
    //_target = GetComponent<Enemy>().Target; //получаем нашего врага, цель
    Reset(_firstState); 
  }

  private void Reset(State startState) 
  {
    _currentState = startState;

    if (_currentState != null) 
      _currentState.Enter(_target);
  }

  private void Update()
  {
    if (_currentState == null) 
      return;

    var nextState = _currentState.GetNextState();
    if (nextState != null) 
      Transit(nextState);
  }

  private void Transit(State nextState)
  {
    if (_currentState != null) 
      _currentState.Exit();

    _currentState = nextState;

    if (_currentState != null)
      _currentState.Enter(_target);
  }
}
