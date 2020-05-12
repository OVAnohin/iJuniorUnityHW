using UnityEngine;

public class SpawnGold : MonoBehaviour
{
  [SerializeField] private Gold _gold = null;

  private Gold _spawnGold;

  private void Awake()
  {
    _spawnGold = Instantiate(_gold, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
  }
}
