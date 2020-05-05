using UnityEngine;

public class SpawnEvilSun : MonoBehaviour
{
  [SerializeField] private EvilSun _evilSun = null;
  [SerializeField] float _timeStart = 0;

  private EvilSun _evilSunClone;

  void Start()
  {
    InvokeRepeating("GenerateEnemy", _timeStart, 2.0f);
  }

  private void GenerateEnemy()
  {
    _evilSunClone = Instantiate(_evilSun, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
  }
}
