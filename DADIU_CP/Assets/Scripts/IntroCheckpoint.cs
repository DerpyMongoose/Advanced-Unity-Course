using UnityEngine;
using System.Collections;

public class IntroCheckpoint : MonoBehaviour {

	void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            GameManager.instance.introCheckPos = true;
        }
    }
}
