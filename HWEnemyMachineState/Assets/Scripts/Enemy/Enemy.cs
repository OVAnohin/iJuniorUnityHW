using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AttackState))]
[RequireComponent(typeof(MoveState))]
[RequireComponent(typeof(JumpState))]

public abstract class Enemy : MonoBehaviour
{
  [SerializeField] protected int Health;
  [SerializeField] protected int Reward;
  [SerializeField] protected float Speed;
  [SerializeField] private Weapon _weapon;
  [SerializeField] private Transform _shootPoing;
  [SerializeField] private float _dieTime;

  public UnityAction<int> EnemyDied;

  private Animator _animator;
  private AttackState _attackState;
  private MoveState _moveState;
  private JumpState _jumpState;
  private bool _isDying = false;

  public float GetSpeed
  {
    get
    { return Speed; }
  }

  public Transform GetShootPoint
  {
    get
    { return _shootPoing; }
  }

  public Weapon GetWeapon
  {
    get
    { return _weapon; }
    protected set { }
  }

  private void Awake()
  {
    _animator = GetComponent<Animator>();
    _attackState = GetComponent<AttackState>();
    _moveState = GetComponent<MoveState>();
    _jumpState = GetComponent<JumpState>();
  }

  public void TakeDamage(int damage)
  {
    Health -= damage;

    if (Health <= 0 && _isDying == false)
    {
      Die();
    }
  }

  private void Die()
  {
    _isDying = true;
    _attackState.enabled = false;
    _moveState.enabled = false;
    _jumpState.enabled = false;

    if (EnemyDied != null)
      EnemyDied(Reward);

    _animator.Play("Die");
    Destroy(gameObject, _dieTime);
  }
}
