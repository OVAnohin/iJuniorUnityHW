using UnityEngine;

public class MonsterMove : MonoBehaviour
{
  [SerializeField] private float _speed = 0;
  [SerializeField] private Transform _groundDetection = null;
  [SerializeField] private LayerMask _whatsIsGround;

  private bool _moveRigth = true;
  private float _distanceCast = 0.5f;

  private void Update()
  {
    transform.Translate(Vector2.right * _speed * Time.deltaTime);
    //RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distanceCast);
    bool groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distanceCast, _whatsIsGround);

    if (groundInfo == false)
    {
      if (_moveRigth == true)
      {
        transform.eulerAngles = new Vector3(0, -180, 0);
        _moveRigth = false;
      }
      else
      {
        transform.eulerAngles = new Vector3(0, 0, 0);
        _moveRigth = true;
      }
    }
  }
}
