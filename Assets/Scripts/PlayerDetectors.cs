using UnityEngine;
using System.Collections;

public class PlayerDetectors : MonoBehaviour {
	public Transform groundCheck,fowardCheck,backCheck;
	float groundRadius=0.05f;
	float wallRadius=0.05f;

	public bool grounded;
	public bool wallJump=false;
	public bool backWall=false;
	public bool wallGrounded=false;
	public bool platform=false;
	public bool inAir=false;
	public bool stopMovement=false;
	public bool wallMoving=false;
	public bool frontGround=false;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		grounded=Physics2D.OverlapCircle(groundCheck.position,groundRadius,1<<LayerMask.NameToLayer ("Ground") );
		wallGrounded=Physics2D.OverlapCircle(groundCheck.position,groundRadius,1<<LayerMask.NameToLayer ("Wall") );
		wallJump = Physics2D.OverlapCircle (fowardCheck.position,wallRadius,1<<LayerMask.NameToLayer ("Wall"));
		backWall = Physics2D.OverlapCircle (backCheck.position,wallRadius,1<<LayerMask.NameToLayer ("Wall"));
		platform =Physics2D.OverlapCircle (groundCheck.position,groundRadius,1<<LayerMask.NameToLayer ("Platform"));
		wallMoving = Physics2D.OverlapCircle (fowardCheck.position,wallRadius,1<<LayerMask.NameToLayer ("MovingWall"));
		frontGround=Physics2D.OverlapCircle (fowardCheck.position,wallRadius,1<<LayerMask.NameToLayer ("Ground"));


		if(wallJump||frontGround){
			if(!grounded && !platform&&!wallGrounded&&!wallMoving ){
			stopMovement= true;
			}
		
		}else {
			stopMovement= false;

		}

		if(!grounded && !platform&&!wallGrounded&&!wallJump&&!frontGround){
			inAir=true;
		}else{
			inAir=false;
		}
	}
	private void OnCollisionEnter2D(Collision2D c){
		if(c.transform.name == "MovingPlatform"){
			transform.parent = c.transform;
		}

	}


	private void OnCollisionExit2D(Collision2D c){

			transform.parent=null;

	}


}
