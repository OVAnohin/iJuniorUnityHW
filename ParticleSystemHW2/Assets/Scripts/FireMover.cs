using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMover : MonoBehaviour
{
  [SerializeField] private float _speed;

  private void OnEbable()
  {
    transform.Translate(Vector3.right * _speed * Time.deltaTime);
  }
}
