using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    GameObject[] collectibles;

    [HideInInspector]
    public int amountOfCollectible;
    [HideInInspector]
    public int recursionMax;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        collectibles = new GameObject[transform.childCount];
        for(int i = 0; i > collectibles.Length; i++)
        {
            collectibles[i] = gameObject.GetComponentInChildren<GameObject>();
        }

        amountOfCollectible = transform.childCount;
        recursionMax = amountOfCollectible;
	}
    void Update()
    {
        if (GameManager.instance.currCollectible == collectibles.Length)
        {
            GameManager.instance.YouWin();
        }
    }
}
