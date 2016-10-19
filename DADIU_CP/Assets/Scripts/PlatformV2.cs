using UnityEngine;
using System.Collections;

public class PlatformV2 : MonoBehaviour {

    public GameObject patrol;
    private Transform[] points;
    public bool autoMove;
    private bool moveBack, left;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start () {
        agent = GetComponentInParent<NavMeshAgent>();
        agent.updateRotation = false;
        points = new Transform[patrol.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = patrol.transform.GetChild(i);
        }
    }
	
	void Update () {
	
        if(moveBack)
        {
            if(!autoMove)
            {
                if (agent.remainingDistance < 0.2f)
                {
                    agent.destination = points[(destPoint + points.Length - 1) % points.Length].position;
                    destPoint--;
                    if (destPoint == 0)
                    {
                        moveBack = false;
                        agent.autoBraking = true;
                        destPoint = 0;
                    }
                }
            }
            else
            {
                if(agent.remainingDistance < 0.2f)
                {
                    if (!left)
                    {
                        agent.destination = points[(int)nfmod((destPoint - 1), points.Length)].position;
                        destPoint--;
                        if (destPoint == 0)
                        {
                            moveBack = false;
                            agent.autoBraking = true;
                            destPoint = 0;
                        }
                    }
                    else
                    {
                        agent.destination = points[(int)nfmod(destPoint, points.Length)].position;
                        destPoint--;
                        if (destPoint == -1)
                        {
                            moveBack = false;
                            agent.autoBraking = true;
                            left = false;
                            destPoint = 0;
                        }
                    }
                }
            }
        }

	}

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        if(autoMove)
        {
            if (!left)
            {
                destPoint = (destPoint + 1) % points.Length;
                if (destPoint == 0)
                {
                    left = true;
                    destPoint = points.Length - 2;
                }
            }
            else
            {
                destPoint = (int)nfmod((destPoint - 1), points.Length);
                if (destPoint == points.Length - 1)
                {
                    left = false;
                    destPoint = 1;
                }
            }
        }
        else
        {
            destPoint += 1;
            if (destPoint == points.Length)
            {
                destPoint = points.Length - 1;
            }
        }

        agent.destination = points[destPoint].position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            CameraController.instance.player.transform.parent = transform;
            GotoNextPoint();
            
        }

    }

    void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            if (agent.remainingDistance < 0.2f)
            {
                GotoNextPoint();
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            CameraController.instance.player.transform.parent = null;
            agent.Stop();
            agent.ResetPath();
            moveBack = true;
            agent.autoBraking = false;

        }
    }

    float nfmod(float a, float b)
    {
        return a - b * Mathf.Floor(a / b);
    }

}
