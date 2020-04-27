using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;
  public float height;

  private Vector3 offset;

  // Start is called before the first frame update
  void Start()
  {
    //offset = new Vector3(0.0f, 0.0f, transform.position.z - player.transform.position.z);
    offset = new Vector3(0.0f, height, 0.0f);
  }

  // Update is called once per frame
  void LateUpdate()
  {
    transform.position = player.transform.position + offset;
  }
}