using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSet : MonoBehaviour
{
  [SerializeField] private TMP_Text _label;
  [SerializeField] private Image _icon;
  [SerializeField] private Button _setButton;

  private Weapon _weapon;
  private Player _player;

  public event UnityAction<Weapon, WeaponSet> SetButtonClick;
  public Weapon Weapon => _weapon;

  private void OnEnable()
  {
    _setButton.onClick.AddListener(OnButtonClick);
  }

  private void OnDisable()
  {
    _setButton.onClick.RemoveListener(OnButtonClick);
  }

  public void Init(Player player)
  {
    _player = player;
  }

  public void Render(Weapon weapon)
  {
    _weapon = weapon;
    _label.text = _weapon.Label;
    _icon.sprite = _weapon.Icon;
    TryLockItem();
  }

  private void OnButtonClick()
  {
    SetButtonClick?.Invoke(_weapon, this);
  }

  private void TryLockItem()
  {
    if (_player.CurrentWeapon == _weapon)
      _setButton.interactable = false;
  }

  public void UnlockSetButton()
  {
    _setButton.interactable = true;
  }
}
