using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private TMP_Text _moneyText;

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
    _moneyText.text = money.ToString();
  }
}
