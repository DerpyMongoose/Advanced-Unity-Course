using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private Rigidbody playerRG;

    private Vector3 zeroVelocity;

    private float distToGround, timer;

    private bool isGrounded = true;

    private RaycastHit hit;

    void Start() {
        playerRG = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y; //finds the distance of the center of the player from the ground
    }


    void FixedUpdate() {

        timer += Time.deltaTime;
        //print(GameManager.instance.playerRG.velocity.magnitude);

        //CHANGED THE ARROW KEYS WITH WASD BECAUSE APPARENTLY THERE IS A HARDWARE LIMITATION WHEN YOU TRY COMBINE UP+LEFT+SPACE!!!!!!!!!!!!!

        if (Input.GetKey("w") && isGrounded && timer > GameManager.instance.timeBtwJumps && GameManager.instance.active)
        {
            playerRG.AddRelativeForce(Vector3.forward * GameManager.instance.playerSpeed);
            playerRG.velocity = zeroVelocity;
        }

        if (Input.GetKey("s") && isGrounded && timer > GameManager.instance.timeBtwJumps && GameManager.instance.active)
        {
            playerRG.AddRelativeForce(-Vector3.forward * GameManager.instance.playerSpeed);
            playerRG.velocity = zeroVelocity;
        }

        if (Input.GetKey("d") && isGrounded && timer > GameManager.instance.timeBtwJumps && GameManager.instance.active)
        {
            //GameManager.instance.playerRG.AddRelativeForce(transform.right * GameManager.instance.playerSpeed);
            //GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
            transform.Rotate(new Vector3(0, GameManager.instance.playerRotation, 0));
        }

        if (Input.GetKey("a") && isGrounded && timer > GameManager.instance.timeBtwJumps && GameManager.instance.active)
        {
            //GameManager.instance.playerRG.AddRelativeForce(-transform.right * GameManager.instance.playerSpeed);
            //GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
            transform.Rotate(new Vector3(0, -GameManager.instance.playerRotation, 0));
        }

        if (Input.GetKey("space") && isGrounded && timer > GameManager.instance.timeBtwJumps && GameManager.instance.active)
        {
            playerRG.AddRelativeForce(transform.up * GameManager.instance.jumpValue);
            playerRG.velocity = zeroVelocity;
            timer = 0;
        }

        if (playerRG.velocity.magnitude > 20)
        {
            if(!GameManager.instance.introCheckPos)
            {
                transform.position = Vector3.zero;
            }
            else
            {
                transform.position = GameManager.instance.waitPoint.position;
            }
        }

    }

    void OnCollisionExit()
    {
        Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity);

        if(hit.distance > 0.8f)
        {
            isGrounded = false;
        }

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }



}
