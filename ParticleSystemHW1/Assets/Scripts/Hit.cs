using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<ManHead>(out ManHead manHead))
    {
      manHead.ShakeHead();
    }
  }

}
