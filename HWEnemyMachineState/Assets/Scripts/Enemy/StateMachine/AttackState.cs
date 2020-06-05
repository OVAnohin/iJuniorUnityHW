using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]

public class AttackState : State
{
  [SerializeField] private float _delay;

  private float _lastAttackTime;
  private Enemy _enemy;
  private Animator _animator;
  private float _delayBeforShoot = 0.45f;
  private float _elapsedTime = 0;
  private bool _isShoot = false;

  private void Awake()
  {
    _enemy = GetComponent<Enemy>();
    _animator = GetComponent<Animator>();
  }

  private void OnEnable()
  {
    _animator.Play("Idle");
  }

  private void Update()
  {
    if (_lastAttackTime <= 0)
    {
      _animator.SetTrigger("Attack");
      _lastAttackTime = _delay;
      _isShoot = true;
      _elapsedTime = 0;
    }

    if (_isShoot && _elapsedTime >= _delayBeforShoot)
    {
      _isShoot = false;
      Attack();
    }

    _elapsedTime += Time.deltaTime;
    _lastAttackTime -= Time.deltaTime;
  }

  private void Attack()
  {
    _enemy.GetWeapon.Attack(_enemy.GetShootPoint);
  }
}
