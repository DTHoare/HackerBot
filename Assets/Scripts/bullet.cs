using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class bullet : MonoBehaviour
{

  public Collider[] spawner;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnCollisionEnter(Collision other)
  {
    if (!spawner.Contains(other.collider))
    {
      Destroy(gameObject);
    }

  }
}
