using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	float speed = 200;
	public float move;
	
	float gravity = 20;
	public float gravityPull;

	float airSpeedMult=0.9f;
	

	
	public bool wallHolding;
	public bool FacingRight=true;
	
	private PlayerController controller;
//	private PlayerControls jump;
	private PlayerDetectors detectors;
	
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		detectors= GetComponent<PlayerDetectors>();
		//jump= GetComponent<PlayerControls>();
	}
	
	// Update is called once per frame
	void Update () {

		//set move to 0 every update
		
		if(controller.moving.x==0 && controller.moving.y==0){
			move = 0;
		}
		//if user moving right
		if (controller.moving.x > 0) {
			//calculate speed
			if(detectors.inAir){
				move= controller.moving.x*(speed*airSpeedMult)*Time.deltaTime;
			}else{
				move= controller.moving.x*speed*Time.deltaTime;
			}
			//holding Shift for run
			if(Input.GetKey(KeyCode.LeftShift)){
				//double Speed
				move= move *2;
				//Add New Run
				Move (move);
				//rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
			}else{
				//Add Normal speed
				Move (move);
				//rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
			}
			
			//change player foward
			flip ();
			
			//if user moving left
		}
		
		if(controller.moving.x <0){
			//calculate speed 
			if(detectors.inAir){
				move= controller.moving.x*(speed*airSpeedMult)*Time.deltaTime;
			}else{
				move= controller.moving.x*speed*Time.deltaTime;
			}
			
			//Holding Shift for run
			if(Input.GetKey(KeyCode.LeftShift)){
				//double Speed
				move=move*2;
				//Add New Run
				Move (move);
				//rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
			}else{
				//Add Normal speed
				Move (move);
				//rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
			}
			//flip player to left
			flip ();
			
			
		}if(controller.moving.x==0){
			//else set x = to 0;
			rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
		}

		
		//calculate Gravity
		gravityPull = gravity * Time.deltaTime;
		//add gravity to player
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y - gravityPull);


	
	}
	public void flip(){
		if(controller.moving.x>0){
			transform.localScale = new Vector3(1, 1, 1);
			FacingRight=true;
		}else if(controller.moving.x<0){
			transform.localScale = new Vector3(-1, 1, 1);
			FacingRight=false;
		}
	}
	public void Move(float move){
		rigidbody2D.velocity = new Vector2(move,rigidbody2D.velocity.y);
	}
}		
