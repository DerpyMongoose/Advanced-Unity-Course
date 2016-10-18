using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            Destroy(gameObject);
            GameManager.instance.currCollectible +=1;
        }
    }
}
