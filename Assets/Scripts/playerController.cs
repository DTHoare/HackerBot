using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

  public float speed;

  private Rigidbody rb;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);
    rb.AddForce(force*speed);

    //putting lookat controls here prevents jittering
    var ray =    Camera.main.ScreenPointToRay(Input.mousePosition);
    var mousePosition = new Vector3(ray.origin.x, transform.position.y, ray.origin.z);
    transform.LookAt(mousePosition);
  }

  void LateUpdate()
  {

  }
}
