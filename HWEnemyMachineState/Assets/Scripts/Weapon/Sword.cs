using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
  public override void Shoot(Transform shootPoint)
  {
  }

  public override void Slash(Transform shootPoint)
  {
    Instantiate(Ammo, shootPoint.position, Quaternion.identity);
  }
}

