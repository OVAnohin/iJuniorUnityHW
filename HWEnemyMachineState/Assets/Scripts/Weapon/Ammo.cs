using System.Collections;
using System.Collections.Generic;
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

  private void Start()
  {
    GetComponent<Rigidbody2D>().isKinematic = true;
  }
}
