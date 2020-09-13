using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
  [SerializeField] private List<Weapon> _weapons = default;
  [SerializeField] private Player _player = default;
  [SerializeField] private WeaponView _template = default;
  [SerializeField] private GameObject _itemContainer = default;

  private void Start()
  {
    for (int i = 0; i < _weapons.Count; i++)
    {
      AddItem(_weapons[i]);
    }
  }

  private void AddItem(Weapon weapon)
  {
    var view = Instantiate(_template, _itemContainer.transform);

    view.Render(weapon);
  }
}
