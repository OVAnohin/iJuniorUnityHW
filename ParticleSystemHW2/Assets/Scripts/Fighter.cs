using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Fighter : MonoBehaviour
{

  private Animator _animator;
  
  private void Start()
  {
    _animator = GetComponent<Animator>();
  }

  public void ShowMovmentOfHead()
  {
    _animator.SetTrigger("Hit");
  }

}
