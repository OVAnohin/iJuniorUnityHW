using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : Ammo
{
  public override void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.GetComponent<Player>() != null)
    {
      collider2D.GetComponent<Player>().ApplyDamage(Damage);
      Destroy(gameObject);
    }
  }
}
