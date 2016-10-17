using UnityEngine;
using System.Collections;


public class Platform : MonoBehaviour
{

    public Transform[] points;
    public bool autoMove;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        //agent.autoBraking = false;

    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        agent.updateRotation = false;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        if (autoMove)
        {
            destPoint = (destPoint + 1) % points.Length;
        }
        else
        {
            if(destPoint != points.Length - 2)
            {
              destPoint += 1;
            }
        }
    }


    //void Update()
    //{
    //    // Choose the next destination point when the agent gets
    //    // close to the current one.
    //    if (agent.remainingDistance < 0.2f)
    //        GotoNextPoint();
    //}

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            //print("Move");
            CameraController.instance.player.transform.parent = transform;
            GotoNextPoint();
        }
        
    }

    void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            if (agent.remainingDistance < 0.2f)
                GotoNextPoint();
        }
    }
    
    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            CameraController.instance.player.transform.parent = null;
            agent.destination = points[points.Length - 1].position;
            destPoint = 0;
        }
    }
}
