using UnityEngine;

public class PlayerMover : MonoBehaviour
{
  [SerializeField] private float _moveSpeed = 5;
  [SerializeField] private float _stepSize = 2;
  [SerializeField] private float _minHeight = -2;
  [SerializeField] private float _maxHeight = 2;

  private Vector3 _targetPosition;

  private void Start()
  {
    _targetPosition = transform.position;
  }

  private void Update()
  {
    if (transform.position != _targetPosition)
    {
      transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
  }

  public void TryMoveUp()
  {
    if (_targetPosition.y < _maxHeight)
      SetTargetPosition(_stepSize);
  }

  public void TryMoveDown()
  {
    if (_targetPosition.y > _minHeight)
      SetTargetPosition(_stepSize * -1);
  }
  private void SetTargetPosition(float stepSize)
  {
    _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize, _targetPosition.z);
  }
}
