using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSword : Ammo
{
  private float _dictanceCovered = 0;

  private void Update()
  {
    if (_dictanceCovered > Distance)
    {
      Destroy(gameObject);
    }

    transform.Translate(Vector2.right * Speed * Time.deltaTime);
    _dictanceCovered += Time.deltaTime;
  }

  private void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.GetComponent<Player>() != null)
    {
      collider2D.GetComponent<Player>().ApplyDamage(Damage);
      Destroy(gameObject);
    }
  }
}
