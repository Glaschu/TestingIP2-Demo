using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {


	public float move;

	float gravity = 20;
	float gravityPull;
	float jumpHeight = 10.5f;

	public int jumpCounter = 0;


	public float jumpPush;
	public float WallHeight;

	public float currentSpeed;
	float targetSpeed;
	Vector2 amountToMove;
	
	public bool wallHolding;

	private PlayerController controller;
	private PlayerDetectors detectors;



	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		detectors= GetComponent<PlayerDetectors>();
	}
	
	// Update is called once per frame
	void Update () {
		//calculate Gravity
		gravityPull = gravity * Time.deltaTime;

		//if wall holding is true then
		if (wallHolding) {
				//set the velocity to 0
				rigidbody2D.velocity= new Vector2 (0,0-gravityPull);
			//if player jump
			if(controller.moving.y>0){

				rigidbody2D.velocity = new Vector2(jumpPush, jumpHeight);

				wallHolding=false;
			}
		}


		//if grounded
		if (detectors.grounded||detectors.platform||detectors.wallGrounded) {
			//keep x velocity and change y to zero
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0-gravityPull);
			//if wallHolding true
			if (wallHolding) 
			{
				//set wallHolding to false;
				wallHolding = false;
			}
			//if press jumpdown; Input.GetButtonDown("Jump")
			if (controller.moving.y>0) {
				//set jumpcount to 1
				jumpCounter = 1;
				//keep same x velocity and change y to jumpHight
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,jumpHeight);
			}

			} else {
			//if wall holding False
			if(!wallHolding){
				//check the detector
				if(detectors.wallJump||detectors.frontGround){
					//set wallHolding to true
					wallHolding=true;
				}
			}


		}

		//if detector.grounded = false and humpCounter =1
		if(detectors.inAir &&jumpCounter==1||(detectors.inAir &&jumpCounter==0)){
			//if input spacebar 
			if (Input.GetButtonDown("Jump")) {
				//set leave x and add jumpheight to y
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,jumpHeight);
				//set jumpCount to 0
				jumpCounter=2;
			}
		}
		if(!detectors.inAir){
			jumpCounter=0;
		}
		//if detector.stopMovement = true
		if (detectors.stopMovement) {
			//set it to zero and and gravity pull to y
			rigidbody2D.velocity = new Vector2 (0, 0-gravityPull*2);
		}else{
			//keep the velocity the same
			rigidbody2D.velocity =new Vector2 (rigidbody2D.velocity.x,rigidbody2D.velocity.y);
		}


		if(wallHolding){
				if(detectors.inAir){
				wallHolding=false;
			}
		}

	
	
	}

}


