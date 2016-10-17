using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    [HideInInspector]
    public bool pushed = false;

    void OnTriggerEnter()
    {
        pushed = true;
    }
}
