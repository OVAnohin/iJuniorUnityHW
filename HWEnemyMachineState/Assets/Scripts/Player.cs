using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
  [SerializeField] private int _health;
  [SerializeField] private List<Weapon> _weapons;
  [SerializeField] private Transform _shootPoing;

  private Weapon _currentWeapon; 
  private int _currentHealth;
  private Animator _animator;
  private float _delayBeforShoot = 0.65f;
  private float _elapsedTime = 0;
  private bool _isShoot = false;

  public List<Weapon> PlayerWeapons => _weapons;
  public Weapon CurrentWeapon => _currentWeapon;
  public int Money { get; private set; }
  public event UnityAction PlayerDied;
  public event UnityAction<int> MoneyChanged;

  private void Start()
  {
    _currentWeapon = _weapons[0];
    _currentHealth = _health;
    _animator = GetComponent<Animator>();
    MoneyChanged?.Invoke(Money);
  }

  public bool IsWeaponInArsenal(Weapon weapon)
  {
    var element = from i in _weapons
                  where i == weapon
                  select i;

    return element != null;
  }

  public bool IsSetWeapon(Weapon weapon)
  {
    for (int i = 0; i < _weapons.Count; i++)
    {
      if (weapon == _weapons[i])
      {
        _currentWeapon = _weapons[i];
        return true;
      }
    }

    return false;
  }

  public void AddMoney(int reward)
  {
    Money += reward;
    MoneyChanged?.Invoke(Money);
  }

  public void ApplyDamage(int damage)
  {
    _currentHealth -= damage;

    if (_currentHealth <= 0)
    {
      _animator.Play("Die");
      PlayerDied?.Invoke();
    }
  }

  public void BuyWeapon(Weapon weapon) 
  {
    Money -= weapon.Price;
    _weapons.Add(weapon);
    MoneyChanged?.Invoke(Money);
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) && _isShoot == false && _currentHealth > 0)
    {
      _animator.SetTrigger("Shoot");
      _isShoot = true;
      _elapsedTime = 0;
    }

    if (_isShoot && _elapsedTime >= _delayBeforShoot)
    {
      _isShoot = false;
      _currentWeapon.Attack(_shootPoing);
    }

    _elapsedTime += Time.deltaTime;
  }
}
