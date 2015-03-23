using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;
		
		if (Input.GetKey ("d")||Input.GetKey(KeyCode.RightArrow)) {
			moving.x = 1;
		}
		if (Input.GetKey ("a")||Input.GetKey(KeyCode.LeftArrow)) {
			moving.x = -1;
		}
		if (Input.GetKey ("a")&&Input.GetKey ("d")){
			moving.x = 0;
		}

		
		if (Input.GetButton ("Jump")) {
		moving.y = 1;
		} else if (Input.GetKey ("s")) {
			moving.y = -1;
		}


	}
}
