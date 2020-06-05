using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Ammo : MonoBehaviour
{
  [SerializeField] protected string Label;
  [SerializeField] protected Sprite Icon;
  [SerializeField] protected int Damage;
  [SerializeField] protected float Speed;
  [SerializeField] protected float Distance;
  [SerializeField] protected bool IsMoveRight;

  private float _dictanceCovered = 0;

  private void Start()
  {
    GetComponent<Rigidbody2D>().isKinematic = true;
  }

  private void Update()
  {
    if (_dictanceCovered > Distance)
      Destroy(gameObject);

    if (IsMoveRight)
      transform.Translate(Vector2.right * Speed * Time.deltaTime);
    else
      transform.Translate(Vector2.left * Speed * Time.deltaTime);
    
    _dictanceCovered += Time.deltaTime;
  }

  public abstract void OnTriggerEnter2D(Collider2D collider2D);
}
