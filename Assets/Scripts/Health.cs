using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  public float health = 100;
  private bool alive = true;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void takeDamage(float damage)
  {
    //Handle death of objects
    if (health <= 0 & alive)
    {
      alive = false;
      if (gameObject.tag == "Player")
      {
        EventManager.TriggerEvent ("PlayerDeath");
      }
      else
      {
        Destroy(gameObject);
      }

    }
    else
    {
      health -= damage;
    }
  }
}
