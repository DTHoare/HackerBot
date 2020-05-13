using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public GameObject player;
  public float height;
  public float behind;

  private Vector3 offset;
  private bool alive = true;

  // Start is called before the first frame update
  void Start()
  {
    //offset = new Vector3(0.0f, 0.0f, transform.position.z - player.transform.position.z);
    offset = new Vector3(0.0f, height, -behind);

    EventManager.StartListening ("PlayerDeath", deathCamera);
  }

  // Update is called once per frame
  void LateUpdate()
  {
    if (alive)
    {
      transform.position = player.transform.position + offset;
      transform.LookAt(player.transform);
    }
    else
    {
      transform.RotateAround(player.transform.position, Vector3.up, 15f * Time.deltaTime);
      transform.LookAt(player.transform);
    }

  }

  void deathCamera()
  {
    offset *= 0.3f;
    alive = false;
    Vector3 newPosition = player.transform.position + offset;
    transform.position = newPosition;
  }
}
