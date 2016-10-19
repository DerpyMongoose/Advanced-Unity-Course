using UnityEngine;
using System.Collections;

public class IntroCheckpoint : MonoBehaviour {

	void OnTriggerExit(Collider col)
    {
        print("Impact");
        if(col.tag == "Player")
        {
            print("Hit the player");
            GameManager.instance.introCheckPos = true;
        }
    }
}
