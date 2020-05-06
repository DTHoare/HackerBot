using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

  public float speed;
  public bool mobile = false;
  public float minDistance = 3.0f;

  private Rigidbody rb;
  private Weapon weapon;
  private Detection detecter;
  private Collider[] selfColliders;
  UnityEngine.AI.NavMeshAgent navMeshAgent;
  private UnityEngine.AI.NavMeshHit hit;
  private Vector3 target;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    weapon = GetComponent<Weapon>();
    detecter = GetComponent<Detection>();
    selfColliders = GetComponentsInChildren<Collider>();
    navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    if (detecter.knownDetectedTarget != null)
    {
      weapon.attemptFire();

      //movement behaviour - close to target but maintain minimum distance
      if (mobile) {
        Vector3 direction = gameObject.transform.position - detecter.knownDetectedTarget.transform.position;
        float sqrDistance = (direction).sqrMagnitude;

        //get closer if far away
        if ( sqrDistance > minDistance*minDistance)
        {
          target = detecter.knownDetectedTarget.transform.position;
        }
        //back up the enemy
        else
        {
          target = transform.position + minDistance * direction / direction.magnitude;
          bool blocked = UnityEngine.AI.NavMesh.Raycast(transform.position, target, out hit, UnityEngine.AI.NavMesh.AllAreas);
          if (blocked)
          {
            target = hit.position;
          }
        }
        navMeshAgent.destination = target;


      }

      // if (target != detecter.knownDetectedTarget)
      // {
      //   target = detecter.knownDetectedTarget;
      //   navMeshAgent.destination = detecter.knownDetectedTarget.transform.position;
      // }
    }
  }

  void FixedUpdate()
  {

  }

  void LateUpdate()
  {
    detecter.detectAgents(selfColliders);
    if (detecter.knownDetectedTarget != null)
    {
      transform.LookAt(detecter.knownDetectedTarget.transform);
    }
  }
}
