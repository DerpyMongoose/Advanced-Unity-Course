using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    [HideInInspector]
    public int currCollectible = 0;
    [HideInInspector]
    public bool active = false;

    [Header("Player Controls")]
    public float playerSpeed = 70; //for movement with physics
    public float playerRotation = 0.3f;
    //public float movingUnits = 0.02f; //that is for movement without physics
    public float jumpValue = 0;
    public float timeBtwJumps = 0.8f;
    public bool introCheckPos = false;
    public Transform waitPoint;

    [Header("Camera Controls")]
    public float camY = 7.5f;
    public float camZ = 10f;

    [Header("Game Managing")]
    public GameObject scoreManager;

    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;
    }

    public void YouWin()
    {
        SceneManager.LoadScene("YouWin!");
    }
}
