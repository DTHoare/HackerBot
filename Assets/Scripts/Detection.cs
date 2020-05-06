using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Detection : MonoBehaviour
{
  [Tooltip("The point representing the source of target-detection raycasts for the enemy AI")]
  public Transform detectionSourcePoint;
  public Actor detectedTarget;
  public float detectionRange = 10f;
  public GameObject knownDetectedTarget;

  ActorManager m_ActorManager;
  Actor actor;

  private void Start()
  {
      m_ActorManager = GameObject.FindObjectOfType<ActorManager>();
      //DebugUtility.HandleErrorIfNullFindObject<ActorManager, Actor>(m_ActorManager, this);
      actor = gameObject.GetComponent<Actor>();

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void detectAgents(Collider[] selfColliders)
  {
    knownDetectedTarget = null;
    float closestDistance = Mathf.Infinity;
    float detectionRangeSquared = detectionRange * detectionRange;

    foreach (Actor otherActor in m_ActorManager.actors)
    {
        if (otherActor.faction != actor.faction)
        {
            float sqrDistance = (otherActor.transform.position - detectionSourcePoint.position).sqrMagnitude;
            if (sqrDistance < detectionRangeSquared && sqrDistance < closestDistance)
            {
                // Check for obstructions
                RaycastHit[] hits = Physics.RaycastAll(detectionSourcePoint.position, (otherActor.aimPoint.position - detectionSourcePoint.position).normalized, detectionRange, -1, QueryTriggerInteraction.Ignore);
                RaycastHit closestValidHit = new RaycastHit();
                closestValidHit.distance = Mathf.Infinity;
                bool foundValidHit = false;
                foreach (var hit in hits)
                {
                    if (!selfColliders.Contains(hit.collider) && hit.distance < closestValidHit.distance)
                    {
                        closestValidHit = hit;
                        foundValidHit = true;
                    }
                }

                if (foundValidHit)
                {
                    Actor hitActor = closestValidHit.collider.GetComponentInParent<Actor>();
                    if (hitActor == otherActor)
                    {
                        detectionRangeSquared = sqrDistance;

                        knownDetectedTarget = otherActor.aimPoint.gameObject;
                    }
                }
            }
        }
      }

  }
}
