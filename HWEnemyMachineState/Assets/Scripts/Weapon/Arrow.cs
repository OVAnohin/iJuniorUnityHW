using UnityEngine;

public class Arrow : Ammo
{
  public override void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.GetComponent<Enemy>() != null)
    {
      collider2D.GetComponent<Enemy>().TakeDamage(Damage);
      Destroy(gameObject);
    }
  }
}
