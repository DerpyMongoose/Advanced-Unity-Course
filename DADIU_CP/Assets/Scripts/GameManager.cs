using UnityEngine;
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

    [Header("Player Controls")]
    public float playerSpeed = 0; //for movement with physics
    //public float movingUnits = 0.02f; //that is for movement without physics
    public float jumpValue = 0;
    public float timeBtwJumps = 0.8f;

    [HideInInspector]
    public bool isCutscene = false;
    [Header("Camera Controls")]
    public float camX = 0;
    public float camY = 7.5f;
    public float camZ = -10f;
    public float cutsceneDistance = 3;
    public float cutsceneTime = 5;

    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;
    }
}
