using UnityEngine;
using System.Collections;

public class MovementNoPhyics : MonoBehaviour {

    private float distToGround;


    void Start () {
        distToGround = GetComponent<Collider>().bounds.extents.y; //finds the distance of the center of the player from the ground
    }
	
	
	//void Update () {
	//    if(Input.GetKey("up") && IsGrounded())
 //       {
 //           transform.position += new Vector3(0, 0, -GameManager.instance.movingUnits);
 //       }
 //       if(Input.GetKey("down") && IsGrounded())
 //       {
 //           transform.position += new Vector3(0, 0, GameManager.instance.movingUnits);
 //       }
 //       if(Input.GetKey("right") && IsGrounded())
 //       {
 //           transform.position += new Vector3(-GameManager.instance.movingUnits, 0, 0);
 //       }
 //       if(Input.GetKey("left") && IsGrounded())
 //       {
 //           transform.position += new Vector3(GameManager.instance.movingUnits, 0, 0);
 //       }
 //       if (Input.GetKey("space") && IsGrounded())
 //       {

 //       }
 //       //print(GameManager.instance.distToGround);
 //   }


    bool IsGrounded()
    {
        print(Physics.Raycast(transform.position, -Vector3.up, distToGround));
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }
}
