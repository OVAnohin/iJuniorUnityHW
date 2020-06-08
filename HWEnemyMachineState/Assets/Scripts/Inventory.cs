using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private WeaponSet _template;
  [SerializeField] private GameObject _itemContainer;

  private void OnEnable()
  {
    for (int i = 0; i < _player.PlayerWeapons.Count; i++)
    {
      AddItem(_player.PlayerWeapons[i]);
    }
  }

  private void OnDisable()
  {
    for (int i = 0; i < _itemContainer.transform.childCount; i++)
    {
      var element = _itemContainer.transform.GetChild(i);
      WeaponSet weaponSet = element.GetComponent<WeaponSet>();
      weaponSet.SetButtonClick -= OnSetButtonClick;
      Destroy(element.gameObject);
    }
  }

  private void AddItem(Weapon weapon)
  {
    WeaponSet view = Instantiate(_template, _itemContainer.transform);
    view.Init(_player);
    view.SetButtonClick += OnSetButtonClick;
    view.Render(weapon);
  }

  private void OnSetButtonClick(Weapon weapon, WeaponSet weaponSet)
  {
    TrySetWeapon(weapon, weaponSet);
  }

  private void TrySetWeapon(Weapon weapon, WeaponSet weaponSet)
  {
    if (_player.IsSetWeapon(weapon))
    {
      weaponSet.Render(weapon);
      ReSetButtonInInventory(weapon);
    }
  }

  private void ReSetButtonInInventory(Weapon weapon)
  {
    for (int i = 0; i < _itemContainer.transform.childCount; i++)
    {
      var element = _itemContainer.transform.GetChild(i);
      WeaponSet weaponSet = element.GetComponent<WeaponSet>();
      if (weaponSet.Weapon != weapon)
      {
        weaponSet.UnlockSetButton();
      }
    }
  }
}
