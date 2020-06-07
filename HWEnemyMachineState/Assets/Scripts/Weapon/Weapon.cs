using UnityEngine;

public class Weapon : MonoBehaviour
{
  [SerializeField] private string _label;
  [SerializeField] private int _price;
  [SerializeField] private Sprite _icon;
  [SerializeField] private bool _isBuyed;
  [SerializeField] private Ammo _ammo;

  public string Label => _label;
  public int Price => _price;
  public Sprite Icon => _icon;
  public bool IsBuy => _isBuyed;

  public void Attack(Transform shootPoint)
  {
    Instantiate(_ammo, shootPoint.position, Quaternion.identity);
  }

  public void Buy()
  {
    _isBuyed = true;
  }
}
