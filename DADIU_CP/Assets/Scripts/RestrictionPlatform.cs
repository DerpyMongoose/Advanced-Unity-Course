using UnityEngine;
using System.Collections;

public class RestrictionPlatform : MonoBehaviour {

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Player")
        {
            agent.Stop();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            agent.Resume();
        }
    }
}
