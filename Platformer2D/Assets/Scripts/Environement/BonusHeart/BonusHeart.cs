using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class BonusHeart : MonoBehaviour
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
      player.TakeBonusLive();
      _audioSource.clip = _takeSound;
      _audioSource.Play();
      Destroy(gameObject, 0.2f);
    }
  }
}
