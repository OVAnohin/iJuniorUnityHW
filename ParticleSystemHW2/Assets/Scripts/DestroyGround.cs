using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyGround : MonoBehaviour
{
  [SerializeField] private Tilemap _tileMap;
  [SerializeField] private Transform _contactPoint;

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Debug.Log(Input.mousePosition);
      Debug.Log(_contactPoint.position);
      _tileMap.SetTile(new Vector3Int((int)_contactPoint.position.x - 1, (int)_contactPoint.position.y - 1, (int)_contactPoint.position.z), null);
    }
  }

  //private void OnTriggerEnter2D(Collider2D collider)
  //{
  //  Tilemap timeMap = collider.GetComponent<Tilemap>();
  //  //timeMap.SetTile(new Vector3Int((int)_contactPoint.position.x - 1, (int)_contactPoint.position.y - 1, (int)_contactPoint.position.z), null);
  //  // Debug.Log((int)_contactPoint.position.y - 1);
  //  //TileBase tileBase = timeMap.GetTile(new Vector3Int((int)_contactPoint.position.x, (int)_contactPoint.position.y - 1, (int)_contactPoint.position.z));
  //  //Debug.Log(tileBase.name);
  //  //tileBase = null;
  //}
}
