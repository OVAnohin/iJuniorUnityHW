using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
  [SerializeField] private UnityEvent _hit;

  public event UnityAction MonsterHit
  {
    add { _hit.AddListener(value); }
    remove { _hit.RemoveListener(value); }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<PlayerControl>() is PlayerControl)
    {
      _hit?.Invoke();
    }
  }
}
