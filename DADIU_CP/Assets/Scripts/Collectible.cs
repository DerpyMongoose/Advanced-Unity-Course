using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    private GameObject player;


	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            Destroy(gameObject,2);
            ScoreManager.instance.amountOfCollectible--;
            GameManager.instance.currCollectible +=1;
        }
    }
}
