using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    [HideInInspector]
    public bool pushed = false;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = transform.position - new Vector3(0,-50f,0);
    }

    void OnTriggerEnter()
    {
        pushed = true;
        transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime);
    }
    void Update()
    {
        if(pushed == false && transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime);
        }
    }
}
