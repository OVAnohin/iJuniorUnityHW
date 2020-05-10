using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour
{
  [SerializeField] private UnityEvent _take;
  [SerializeField] private Gold _gold = null;

  public bool Taked { get; private set; }

  private void Start()
  {
    Instantiate(_gold, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
  }

  public event UnityAction TakeGold
  {
    add { _take.AddListener(value); }
    remove { _take.RemoveListener(value); }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<PlayerControl>() is PlayerControl)
    {
      Taked = true;
      _take?.Invoke();
    }
  }
}
