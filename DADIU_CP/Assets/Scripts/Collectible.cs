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
            gameObject.SetActive(false);
            //Destroy(Tree.instance.startObject.GetComponent<MeshFilter>());
            //Tree.instance.startObject.AddComponent<MeshFilter>();
            //Tree.instance.startObject.GetComponent<MeshFilter>().mesh = Tree.instance.mesh;
            //Tree.instance.mesh = null;
            //Tree.instance.CreateTree();
            ScoreManager.instance.amountOfCollectible--;
            //print(ScoreManager.instance.amountOfCollectible);
            GameManager.instance.currCollectible +=1;
        }
    }
}
