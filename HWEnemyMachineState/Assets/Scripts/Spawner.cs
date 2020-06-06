using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private List<Wave> _waves;
  [SerializeField] private Transform _spawnPoint;

  private Wave _currentWave;
  private int _currentWaveNumber = 0;
  private float _timeAfterLastSpawn;
  private int _spawned;
  private System.Random rand = new System.Random();

  public event UnityAction<int, int> EnemySpawnChanged;
  public event UnityAction AllEnemySpawned;

  private void Start()
  {
    SetWave(_currentWaveNumber);
    EnemySpawnChanged?.Invoke(0, 1);
  }

  private void Update()
  {
    if (_currentWave == null)
      return;

    _timeAfterLastSpawn += Time.deltaTime;

    if (_timeAfterLastSpawn >= _currentWave.Delay)
    {
      InstantiateEnemy();
      _spawned++;
      EnemySpawnChanged?.Invoke(_spawned, _currentWave.Count);
      _timeAfterLastSpawn = 0;
    }

    if (_currentWave.Count <= _spawned)
    {
      if (_waves.Count > _currentWaveNumber + 1)
      {
        AllEnemySpawned?.Invoke();
      }

      _currentWave = null;
    }
  }

  private void InstantiateEnemy()
  {
    int index = rand.Next(0, _currentWave.Templates.Count);
    Enemy enemy = Instantiate(_currentWave.Templates[index], _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
    enemy.Init(_player);
    enemy.Dying += OnEnemyDying;
  }

  public void NextWave()
  {
    EnemySpawnChanged?.Invoke(0, 1);
    SetWave(++_currentWaveNumber);
    _spawned = 0;
  }

  private void SetWave(int index)
  {
    _currentWave = _waves[index];
  }

  private void OnEnemyDying(Enemy enemy)
  {
    enemy.Dying -= OnEnemyDying; 
    _player.AddMoney(enemy.GetReward);
  }
}

[System.Serializable]
public class Wave
{
  public List<GameObject> Templates;
  public float Delay;
  public int Count;
}
