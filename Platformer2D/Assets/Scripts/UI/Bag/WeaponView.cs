using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
  [SerializeField] private TMP_Text _label = default;
  [SerializeField] private Image _icon = default;
  [SerializeField] private Button _useButton = default;

  public event UnityAction<Weapon, WeaponView> UseButtonClick;

  private Weapon _weapon;

  private void OnEnable()
  {
    _useButton.onClick.AddListener(OnButtonClick);
  }

  private void OnDisable()
  {
    _useButton.onClick.RemoveListener(OnButtonClick);
  }

  public void Render(Weapon weapon)
  {
    _weapon = weapon;

    _label.text = weapon.GetLabel;
    _icon.sprite = weapon.GetSprite;
  }

  private void OnButtonClick()
  {
    UseButtonClick?.Invoke(_weapon, this);
  }
}
