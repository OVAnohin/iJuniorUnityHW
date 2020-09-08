using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  [SerializeField] private int _health = 0;
  [SerializeField] private SpriteRenderer _weaponRender = default;
  [SerializeField] private Weapon _weapon = default;

  public int Money { get; private set; } 
  public event UnityAction<int, int> HealthChanged; 
  public event UnityAction<int> MoneyChanged; 
  public event UnityAction<Weapon> WeaponChanged; 

  private List<Weapon> _weapons = new List<Weapon>(); 
  private int _currentHealth;    

  private void Start()
  {
    _weapons.Add(_weapon);
    _currentHealth = _health;
    _weaponRender.sprite = _weapon.GetSprite;

    HealthChanged?.Invoke(_currentHealth, _health);
    WeaponChanged?.Invoke(_weapon);
  }

  public void AddMoney(int reward)
  {
    Money += reward;
    MoneyChanged?.Invoke(Money);
  }

  public void TakeDamage(int damage)
  {
    _currentHealth -= damage;
    HealthChanged?.Invoke(_currentHealth, _health);

    if (_currentHealth <= 0)
      Destroy(gameObject);
  }

  public void Equip(Weapon weapon)
  {
    TryToAddWeapon(weapon);
    _weapon = weapon;
    _weaponRender.sprite = weapon.GetSprite;
    WeaponChanged?.Invoke(_weapon);
  }

  private void TryToAddWeapon(Weapon weapon)
  {
    var foundWeapon = _weapons.Where(w => w.GetLabel == weapon.GetLabel).FirstOrDefault();
    if (foundWeapon == null)
      _weapons.Add(weapon);

  }
}
