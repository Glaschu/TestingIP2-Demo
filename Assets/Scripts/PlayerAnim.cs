using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	private Animator animator;
	private PlayerController controller;
	private PlayerDetectors detectors;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		controller = GetComponent<PlayerController>();
		detectors= GetComponent<PlayerDetectors>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller.moving.x !=0){
			animator.SetInteger ("AnimState", 1);
		}else if(controller.moving.y !=0){
			animator.SetInteger ("AnimState", 2);
		}else{
			animator.SetInteger ("AnimState", 0);
		}
	
		if(detectors.inAir){
			animator.SetInteger ("AnimState", 2);
		}
		if(detectors.wallJump||detectors.frontGround){
			animator.SetInteger ("AnimState", 3);
		}

	}
}
