using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Monster))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Gold))]

public class PlayerControl : MonoBehaviour
{
  private Monster _monster;
  private Gold[] _golds;
  private SpriteRenderer _spriteRenderer;
  private float _durationHit = 2;
  private Color _startColor;
  private Color _hitColor = Color.red;

  private void Start()
  {
    _monster = FindObjectOfType<Monster>();
    _golds = FindObjectsOfType<Gold>();
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _startColor = _spriteRenderer.color;
    _monster.MonsterHit += MonsterHit;
    for (int i = 0; i < _golds.Length; i++)
    {
      _golds[i].TakeGold += TakeGold;
    }
  }

  private void TakeGold()
  {
    for (int i = 0; i < _golds.Length; i++)
    {
      if (_golds[i].Taked)
      {
        _golds[i].TakeGold -= TakeGold;
        Destroy(_golds[i].gameObject);
      }
    }
  }

  private void MonsterHit()
  {
    StartCoroutine(MonsterHitSignal());
  }

  private IEnumerator MonsterHitSignal()
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
