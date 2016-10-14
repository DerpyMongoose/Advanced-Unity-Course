using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


    void Start() {
        GameManager.instance.playerRG = GetComponent<Rigidbody>();
        GameManager.instance.distToGround = GetComponent<Collider>().bounds.extents.y; //finds the distance of the center of the player from the ground
    }


    void FixedUpdate() {

        GameManager.instance.timer += Time.deltaTime;

        //CHANGED THE ARROW KEYS WITH WASD BECAUSE APPARENTLY THERE IS A HARDWARE LIMITATION WHEN YOU TRY COMBINE UP+LEFT+SPACE!!!!!!!!!!!!!

        if (Input.GetKey("w") && GameManager.instance.isGrounded && GameManager.instance.timer > GameManager.instance.timeBtwJumps)
        {
            GameManager.instance.playerRG.AddRelativeForce(transform.forward * GameManager.instance.playerSpeed);
            GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
        }

        if (Input.GetKey("s") && GameManager.instance.isGrounded && GameManager.instance.timer > GameManager.instance.timeBtwJumps)
        {
            GameManager.instance.playerRG.AddRelativeForce(-transform.forward * GameManager.instance.playerSpeed);
            GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
        }

        if (Input.GetKey("d") && GameManager.instance.isGrounded && GameManager.instance.timer > GameManager.instance.timeBtwJumps)
        {
            GameManager.instance.playerRG.AddRelativeForce(transform.right * GameManager.instance.playerSpeed);
            GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
        }

        if (Input.GetKey("a") && GameManager.instance.isGrounded && GameManager.instance.timer > GameManager.instance.timeBtwJumps)
        {
            GameManager.instance.playerRG.AddRelativeForce(-transform.right * GameManager.instance.playerSpeed);
            GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
        }

        if (Input.GetKey("space") && GameManager.instance.isGrounded && GameManager.instance.timer > GameManager.instance.timeBtwJumps)
        {
            GameManager.instance.playerRG.AddRelativeForce(transform.up * GameManager.instance.jumpValue);
            GameManager.instance.playerRG.velocity = GameManager.instance.zeroVelocity;
            GameManager.instance.timer = 0;
        }

    }

    void OnCollisionExit()
    {
        print("not impact");
        Physics.Raycast(transform.position, -Vector3.up, out GameManager.instance.hit, Mathf.Infinity);

        if(GameManager.instance.hit.distance > 0.8f)
        {
            GameManager.instance.isGrounded = false;
        }
    }

    void OnCollisionStay()
    {
        print("Impact");
        GameManager.instance.isGrounded = true;
    }


}
