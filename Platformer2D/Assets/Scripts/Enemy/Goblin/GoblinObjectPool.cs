using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoblinObjectPool : MonoBehaviour
{
  [SerializeField] private GameObject _container = default;
  [SerializeField] private int _capacity = default;

  private List<Goblin> _pool = new List<Goblin>();

  protected void Init(Goblin prefab)
  {
    for (int i = 0; i < _capacity; i++)
    {
      Goblin spawned = Instantiate(prefab, _container.transform);
      spawned.gameObject.SetActive(false);
      _pool.Add(spawned);
    }
  }

  protected bool TryGetObject(out Goblin result)
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
