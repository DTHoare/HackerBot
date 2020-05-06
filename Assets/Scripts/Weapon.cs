using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  public GameObject bullet;
  private float fireDelay = -1f;
  private Collider[] selfColliders;
  private string faction;

  // Start is called before the first frame update
  void Start()
  {
    selfColliders = GetComponentsInChildren<Collider>();
    faction = GetComponentInParent<Actor>().faction;
  }

  // Update is called once per frame
  void Update()
  {
    if (fireDelay > 0f)
    {
      fireDelay -= Time.deltaTime;
    }
  }

  public void attemptFire()
  {
    if (fireDelay < 0f)
    {
      fireDelay = 0.33f;
      GameObject instBullet = Instantiate(bullet, transform.position + 0.5f*transform.forward, transform.rotation) as GameObject;
      Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
      instBullet.GetComponent<bullet>().spawner = selfColliders;
      instBullet.GetComponent<DamageOnCollision>().faction = faction;

      instBulletRigidbody.velocity = instBulletRigidbody.transform.forward * 15;
      //max life
      Destroy(instBullet, 10.0f);
    }
  }
}
