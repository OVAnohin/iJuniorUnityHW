using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
  [SerializeField] private ParticleSystem _punch;
  [SerializeField] private Animator _animator;

  private void Start()
  {
    _punch.Stop();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
    {
      _punch.Play();
      _animator.SetTrigger("Punch");
    }
  }
}
