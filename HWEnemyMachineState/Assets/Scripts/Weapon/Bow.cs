﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
  public override void Shoot(Transform shootPoint)
  {
    Instantiate(Ammo, shootPoint.position, Quaternion.identity);
  }

  public override void Slash(Transform shootPoint)
  {
  }

}
