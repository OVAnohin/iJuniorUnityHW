using UnityEngine;

public class Weapon : MonoBehaviour
{
  [SerializeField] private string _label;
  [SerializeField] private int _price;
  [SerializeField] private Sprite _icon;
  [SerializeField] private bool _isBuy;
  [SerializeField] private Ammo _ammo;

  public void Attack(Transform shootPoint)
  {
    Instantiate(_ammo, shootPoint.position, Quaternion.identity);
  }
}
