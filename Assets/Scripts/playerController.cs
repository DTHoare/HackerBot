using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

  public float speed;

  private Rigidbody rb;
  private Weapon weapon;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    weapon = GetComponent<Weapon>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      weapon.attemptFire();
    }
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);
    //rb.AddForce(force*speed);
    rb.velocity = force*speed;

    //putting lookat controls here prevents jittering
    var ray =    Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 8)))
    {
      transform.LookAt(hit.point);
    }


  }

  void LateUpdate()
  {

  }
}
