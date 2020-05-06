using System.Collections;
using UnityEngine;

public class SpawnEvilSun : MonoBehaviour
{
  [SerializeField] private EvilSun _evilSun = null;
  [SerializeField] private int _numberOfSequenceOfStart = 0;

  private EvilSun _evilSunClone;

  private void Start()
  {
    StartCoroutine(GenerateEnemy());
  }

  private IEnumerator GenerateEnemy()
  {
    while (true)
    {
      if (_numberOfSequenceOfStart > 0)
      {
        _numberOfSequenceOfStart--;
        yield return new WaitForSeconds(1f);
      }
      _evilSunClone = Instantiate(_evilSun, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
      yield return new WaitForSeconds(2f);
    }
  }
}
