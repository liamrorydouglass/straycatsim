using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_controller : MonoBehaviour
{
	CharacterController characterController;

   	public float acc;
   	public float maxSpeed = 4.0f;
   	public float jumpForceMax = 0.0f;
   	public float rotSpeed = 50.0f;
   	public float sprintMod = 2f;


   	private float haxis;
   	private float vaxis;
   	private float tempAcc;
   	private bool isSprinting = false;



   	private Vector3 moveDirection = Vector3.zero; 
    // Start is called before the first frame update
    void Start()
    {
    	characterController = GetComponent<CharacterController>();

    }
 
    // Update is called once per frame
    void Update()
    {
    	//if(characterController.isGrounded){
    	checkSprint();
        haxis = Input.GetAxis("Horizontal");
        vaxis = Input.GetAxis("Vertical");
    	//}
        Debug.Log(tempAcc);
		transform.Rotate(0.0f, haxis * Time.deltaTime * rotSpeed, 0.0f);
		transform.Translate(-vaxis * Time.deltaTime * tempAcc, 0.0f, 0.0f);
			
	}

	void checkSprint(){
		if(Input.GetKey(KeyCode.LeftShift)){
			isSprinting = true;
			tempAcc = acc * sprintMod;
		}
		else{
			isSprinting = false;
			tempAcc = acc;
		}
	}
}

/*
using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class movement_controller : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}*/