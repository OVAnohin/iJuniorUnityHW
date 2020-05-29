using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Ammo
{
  private float _dictanceCovered = 0;

  private void Update()
  {
    if (_dictanceCovered > Distance)
    {
      Destroy(gameObject);
    }

    transform.Translate(Vector2.left * Speed * Time.deltaTime);
    _dictanceCovered += Time.deltaTime;
  }

  private void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.GetComponent<Enemy>() != null)
    {
      collider2D.GetComponent<Enemy>().TakeDamage(Damage);
      Destroy(gameObject);
    }
  }
}
