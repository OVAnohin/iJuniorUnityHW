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

  public event UnityAction<Enemy> Dying;

  private Animator _animator;
  private AttackState _attackState;
  private MoveState _moveState;
  private JumpState _jumpState;
  private bool _isDying = false;
  private Player _target; 

  public Player Target => _target; 
  public float GetSpeed => Speed;
  public Transform GetShootPoint => _shootPoing;
  public Weapon GetWeapon
  {
    get { return _weapon; }
    protected set { }
  }
  public int GetReward => Reward;

  private void Awake()
  {
    _animator = GetComponent<Animator>();
    _attackState = GetComponent<AttackState>();
    _moveState = GetComponent<MoveState>();
    _jumpState = GetComponent<JumpState>();
  }

  public void Init(Player player)
  {
    _target = player;
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

    Dying?.Invoke(this);
    _animator.Play("Die");
    Destroy(gameObject, _dieTime);
  }
}
