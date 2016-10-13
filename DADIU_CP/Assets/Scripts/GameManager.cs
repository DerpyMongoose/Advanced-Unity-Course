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

    public float playerSpeed = 0; //for movement with physics
    //public float movingUnits = 0.02f; //that is for movement without physics
    public float jumpValue = 0;
    public float timeBtwJumps = 0.8f;

    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;
    }
}
