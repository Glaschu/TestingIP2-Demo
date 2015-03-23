using UnityEngine;
using System.Collections;

public class FadeingPlatform : MonoBehaviour {
	public float fadeDelay=2f;
	public bool fadeBool;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		if(fadeBool){

			StartCoroutine (fadeing());
			}
	}
	IEnumerator fadeing(){
		yield return new WaitForSeconds(fadeDelay);
		gameObject.SetActive (false);
	}
	private void OnCollisionEnter2D(Collision2D c){
		if(c.transform.name == "player"){
			fadeBool=true;
		}
		
	}
}

