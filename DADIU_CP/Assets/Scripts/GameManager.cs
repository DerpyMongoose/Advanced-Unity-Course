using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [HideInInspector]
    public Rigidbody playerRG;
    [HideInInspector]
    public Vector3 zeroVelocity;
    [HideInInspector]
    public float distToGround, timer;
    [HideInInspector]
    public bool isGrounded = true;
    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public int currCollectible = 0;

    [Header("Player Controls")]
    public float playerSpeed = 70; //for movement with physics
    public float playerRotation = 0.3f;
    //public float movingUnits = 0.02f; //that is for movement without physics
    public float jumpValue = 0;
    public float timeBtwJumps = 0.8f;

    [HideInInspector]
    public bool isCutscene = false;
    [Header("Camera Controls")]
    public float camX = 0;
    public float camY = 7.5f;
    public float camZ = -10f;

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
