using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  [SerializeField] protected string Label;
  [SerializeField] protected int Price;
  [SerializeField] protected Sprite Icon;
  [SerializeField] protected bool IsBuy;
  [SerializeField] protected Ammo Ammo;
  [SerializeField] private bool _isMelee;

  public bool IsMelee
  {
    get { return _isMelee; }
  }

  public abstract void Shoot(Transform shootPoint);

  public abstract void Slash(Transform shootPoint);
}
