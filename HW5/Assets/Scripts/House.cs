using UnityEngine;

public class House : MonoBehaviour
{
  [SerializeField] private Lamp _lamp;

  private Animator _anim;
  private Door _door;
  private Lamp _cloneLamp;

  private void Start()
  {
    _anim = GetComponent<Animator>();
    _door = FindObjectOfType<Door>();
    _door.Inside += _door_Inside;
    _door.Outside += _door_Outside;
  }

  private void _door_Outside()
  {
    _anim.SetBool("isIndoors", false);
    Destroy(_cloneLamp.gameObject);
  }
  private void _door_Inside()
  {
    _anim.SetBool("isIndoors", true);
    _cloneLamp = Instantiate(_lamp, transform.position + new Vector3(0,-0.5f, 0), Quaternion.identity);
  }

  private void FixedUpdate()
  {
    if (_cloneLamp is Lamp)
    {
      AudioSource sound = _cloneLamp.GetComponent<AudioSource>();
      if (sound.volume < 1)
      {
        sound.volume += 0.001f;
      }
    }
  }
}
