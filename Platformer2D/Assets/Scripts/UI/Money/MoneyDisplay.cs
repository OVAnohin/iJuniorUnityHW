﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
  [SerializeField] private Player _player = default;
  [SerializeField] TMP_Text _money = default;

  private void OnEnable()
  {
    _player.MoneyChanged += OnMoneyChanged;
  }

  private void OnDisable()
  {
    _player.MoneyChanged -= OnMoneyChanged;
  }
  private void OnMoneyChanged(int money)
  {
    _money.text = money.ToString();
  }
}
