﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
  [SerializeField] private Transform[] _movePoints = new Transform[0];
  [SerializeField] private float _speed = 0;
  [SerializeField] private float _waitTime = 0;

  private int _currenIndex;
  private float _elapsedTime = 0;

  private void Start()
  {
    _currenIndex = 0;
  }

  private void Update()
  {
    transform.position = Vector2.MoveTowards(transform.position, _movePoints[_currenIndex].position, _speed * Time.deltaTime);

    if (transform.position.y == _movePoints[_currenIndex].position.y)
    {
      if (_elapsedTime >= _waitTime)
      {
        SetNewIndex();
        _elapsedTime = 0;
      }

      _elapsedTime += Time.deltaTime;
    }
  }

  private void SetNewIndex()
  {
    int arrLength = _movePoints.Length;

    if (++_currenIndex >= arrLength)
      _currenIndex = 0;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<Player>() != null)
    {
      collision.transform.parent = transform;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.GetComponent<Player>() != null)
    {
      collision.transform.parent = null;
    }
  }
}
