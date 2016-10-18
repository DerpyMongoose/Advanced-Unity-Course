using UnityEngine;
using System.Collections;

public class RestrictionPlatform : MonoBehaviour {

    private NavMeshAgent agent;

    //Ask about the issue of the rigidbodies when the platform is having remaining distance < 0.2f 
    //then it pushes the player in order to finish its movement and as a result the player 
    //is either pushed into the cubes or doing some weird movement to the side (due to the force the player receives).

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
