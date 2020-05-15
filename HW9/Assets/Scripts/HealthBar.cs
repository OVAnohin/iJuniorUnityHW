using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField] private Slider _slider = null;
  [SerializeField] private float _duration = 1f;

  private bool _isChanging;
  private float _step = 0.05f;

  public void OnButtonClickHeal()
  {
    if (!_isChanging)
      StartCoroutine(ChangeLife(_step));
  }

  public void OnButtonClickHit()
  {
    if (!_isChanging)
      StartCoroutine(ChangeLife(_step * -1));
  }

  private IEnumerator ChangeLife(float value)
  {
    float _min = _slider.value;
    float _max = _min + value;
    float runningTime = 0;
    float normalizeValue = 0;

    _isChanging = true;

    while (runningTime < _duration)
    {
      runningTime += Time.deltaTime;
      normalizeValue = runningTime / _duration;
      _slider.value = Mathf.Lerp(_min, _max, normalizeValue);

      yield return null;
    }

    _isChanging = false;
  }
}
