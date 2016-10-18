using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    GameObject[] collectibles;

	// Use this for initialization
	void Start ()
    {
        collectibles = new GameObject[transform.childCount];
        for(int i = 0; i > collectibles.Length; i++)
        {
            collectibles[i] = gameObject.GetComponentInChildren<GameObject>();
        }
	}
    void Update()
    {
        if (GameManager.instance.currCollectible == collectibles.Length)
        {
            GameManager.instance.YouWin();
        }
    }
}
