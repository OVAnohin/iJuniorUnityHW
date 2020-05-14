using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField] private Slider _slider;

  public void OnButtonClickHeal()
  {
    _slider.value += 1;
  }

  public void OnButtonClickHit()
  {
    _slider.value -= 1;
  }
}
