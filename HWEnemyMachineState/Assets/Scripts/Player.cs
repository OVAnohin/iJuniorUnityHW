using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
  [SerializeField] private int _health;
  [SerializeField] private List<Weapon> _weapons;
  [SerializeField] private Transform _shootPoing;

  public int Money { get; private set; }
  public event UnityAction PlayerDied;
  public event UnityAction<int, int> HealthChanged;

  private Weapon _currentWeapon; 
  private int _currentHealth;
  private Animator _animator;
  private float _delayBeforShoot = 0.65f;
  private float _elapsedTime = 0;
  private bool _isShoot = false;

  private void Start()
  {
    _currentWeapon = _weapons[0];
    _currentHealth = _health;
    _animator = GetComponent<Animator>();
  }

  public void AddMoney(int reward)
  {
    Money += reward;
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

  private void OnEnemyDyed(int reward)
  {
    Money += reward;
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
