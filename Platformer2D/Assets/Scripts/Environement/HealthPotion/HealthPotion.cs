using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HealthPotion : MonoBehaviour
{
  [SerializeField] private AudioClip _takeSound = default;

  private AudioSource _audioSource;

  private void Start()
  {
    _audioSource = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.TryGetComponent<Player>(out Player player))
    {
      player.TakeHealthPotion();
      player.TakeBonusLive();
      _audioSource.clip = _takeSound;
      Destroy(gameObject, 0.2f);
    }
  }
}
