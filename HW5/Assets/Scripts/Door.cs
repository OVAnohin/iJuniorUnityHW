using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
  [SerializeField] private UnityEvent _inside;
  [SerializeField] private UnityEvent _outside;

  public event UnityAction Inside
  {
    add { _inside.AddListener(value); }
    remove { _inside.RemoveListener(value); }
  }

  public event UnityAction Outside
  {
    add { _outside.AddListener(value); }
    remove { _outside.RemoveListener(value); }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.GetComponent<Thief>() is Thief)
    {
      SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
      if (sr.flipX)
        _outside?.Invoke();
      else
        _inside?.Invoke();
    }
  }
}
