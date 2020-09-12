using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHeart : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.TryGetComponent<Player>(out Player player))
    {
      player.TakeBonusLive();
      Destroy(gameObject);
    }

  }
}
