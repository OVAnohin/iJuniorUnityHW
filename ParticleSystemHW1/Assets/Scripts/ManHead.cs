using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ManHead : MonoBehaviour
{

  private Animator _animator;

  private void Start()
  {
    _animator = GetComponent<Animator>();
  }
  public void ShakeHead()
  {
    _animator.SetTrigger("Hit");
  }
}
