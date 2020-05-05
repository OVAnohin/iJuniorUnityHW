using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
  [SerializeField] private UnityEvent _opened;
  [SerializeField] private UnityEvent _closed;

  public event UnityAction Opened
  {
    add { _opened.AddListener(value); }
    remove { _opened.RemoveListener(value); }
  }

  public event UnityAction Closed
  {
    add { _closed.AddListener(value); }
    remove { _closed.RemoveListener(value); }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.GetComponent<Thief>() is Thief)
    {
      SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
      if (sr.flipX)
        _closed?.Invoke();
      else
        _opened?.Invoke();
    }
  }
}
