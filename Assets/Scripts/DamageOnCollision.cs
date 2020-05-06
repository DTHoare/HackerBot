using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
  public float damage = 0f;
  public string faction;
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
    Health health = other.gameObject.GetComponent<Health>();
    if (health != null)
    {
      Actor actor = other.gameObject.GetComponentInParent<Actor>();
      if(actor.faction != faction)
      {
        health.takeDamage(damage);
      }
    }

  }
}
