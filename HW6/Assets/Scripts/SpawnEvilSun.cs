using System.Collections;
using UnityEngine;

public class SpawnEvilSun : MonoBehaviour
{
  [SerializeField] private EvilSun _evilSun = null;
  [SerializeField] private int _numberOfSequenceOfStart = 1;

  private EvilSun _evilSunClone;
  private float _timer = 0;

  private void Update()
  {
    if (_timer <= _numberOfSequenceOfStart)
    {
      _timer += Time.deltaTime;
      if (_timer >= _numberOfSequenceOfStart)
      {
        StartCoroutine(GenerateEnemy());
        _timer += Time.deltaTime;
      }
    }
  }

  private IEnumerator GenerateEnemy()
  {
    while (true)
    {
      _evilSunClone = Instantiate(_evilSun, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
      yield return new WaitForSeconds(2f);
    }
  }
}
