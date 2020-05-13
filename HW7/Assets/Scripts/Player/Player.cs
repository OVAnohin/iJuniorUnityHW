using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
  private Color _startColor;
  private Color _hitColor = Color.red;
  private SpriteRenderer _spriteRenderer;
  private float _durationHit = 2;

  private void Start()
  {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _startColor = _spriteRenderer.color;
  }

  public void TakeDamage()
  {
    StartCoroutine(ShowHitDamage());
  }

  private IEnumerator ShowHitDamage()
  {
    float runningTime = 0;
    float normalizeTime = 0;
    while (runningTime < _durationHit)
    {
      runningTime += Time.deltaTime;
      normalizeTime = runningTime / _durationHit;
      if (normalizeTime <= 0.5f)
        _spriteRenderer.color = Color.Lerp(_startColor, _hitColor, normalizeTime);
      else
        _spriteRenderer.color = Color.Lerp(_hitColor, _startColor, normalizeTime);

      yield return null;
    }
  }
}
