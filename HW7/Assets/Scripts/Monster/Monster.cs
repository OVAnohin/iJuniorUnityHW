using UnityEngine;

public class Monster : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<Player>() is Player)
    {
      collision.GetComponent<Player>().TakeDamage();
    }
  }
}
