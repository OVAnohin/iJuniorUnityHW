using UnityEngine;

public class Gold : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<Player>() is Player)
    {
      Destroy(gameObject);
    }
  }
}
