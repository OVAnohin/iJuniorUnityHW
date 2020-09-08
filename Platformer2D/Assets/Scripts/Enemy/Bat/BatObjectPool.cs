using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BatObjectPool : MonoBehaviour
{
  [SerializeField] private int _capacity = 0;

  private List<Bat> _pool = new List<Bat>();

  protected void Init(Bat prefab)
  {
    for (int i = 0; i < _capacity; i++)
    {
      Bat spawned = Instantiate(prefab, transform);
      spawned.gameObject.SetActive(false);
      _pool.Add(spawned);
    }
  }

  protected bool TryGetObject(out Bat result)
  {
    result = _pool.Where(p => p.gameObject.activeSelf == false).FirstOrDefault();
    return result != null;
  }

  public void ResetPool()
  {
    foreach (var item in _pool)
      item.gameObject.SetActive(false);
  }
}
