using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private bool pushed = false;

    void OnTriggerEnter()
    {
        pushed = true;
    }
}
