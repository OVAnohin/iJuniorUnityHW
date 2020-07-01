using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireBall : MonoBehaviour
{
  [SerializeField] ParticleSystem _particleSystem;

  private void Start()
  {
    _particleSystem.Stop();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _particleSystem.Play();
    }
  }
}
