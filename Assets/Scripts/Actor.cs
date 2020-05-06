using UnityEngine;

// This class contains general information describing an actor (player or enemies).
// It is mostly used for AI detection logic and determining if an actor is friend or foe
public class Actor : MonoBehaviour
{
    [Tooltip("Represents the faction (or team) of the actor. Actors of the same faction are friendly to eachother")]
    public string faction;
    [Tooltip("Represents point where other actors will aim when they attack this actor")]
    public Transform aimPoint;

    ActorManager m_ActorManager;

    private void Start()
    {
        m_ActorManager = GameObject.FindObjectOfType<ActorManager>();
        //DebugUtility.HandleErrorIfNullFindObject<ActorManager, Actor>(m_ActorManager, this);

        // Register as an actor
        if (!m_ActorManager.actors.Contains(this))
        {
            m_ActorManager.actors.Add(this);
        }
    }

    private void OnDestroy()
    {
        // Unregister as an actor
        if (m_ActorManager)
        {
            m_ActorManager.actors.Remove(this);
        }
    }
}
