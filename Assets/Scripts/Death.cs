using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour 
{
	string scene;
	public GameObject Player;

	public GameObject Checkpoint1;
	public GameObject Checkpoint2;
	public GameObject Checkpoint3;

	 int CheckpointI = 1;
	 int CheckpointII = 2;
	 int CheckpointIII = 3;
	 int CurrentCheckpoint = 0;


	void OnTriggerEnter2D(Collider2D target)
	{
		//Activate Death Process
		if (target.gameObject.tag == "Deadly") 
		{
			OnDeath();
		}

		//set current Checkpoint
		if (target.gameObject.tag == "CheckpointI") 
		{
			CurrentCheckpoint = CheckpointI;
		}
		if (target.gameObject.tag == "CheckpointII") 
		{
			CurrentCheckpoint = CheckpointII;
		}
		if (target.gameObject.tag == "CheckpointIII") 
		{
			CurrentCheckpoint = CheckpointIII;
		}
	}
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Deadly") 
		{
			//Kill Player
			OnDeath();
		}
	}

	public void OnDeath()
	{
		//Recreate Player
		if (CurrentCheckpoint == 0) 
		{
			scene = Application.loadedLevelName;
			Application.LoadLevel (scene);
		}
		if (CurrentCheckpoint == 1) 
		{
			Player.transform.position =  Checkpoint1.transform.position;
		
		}
		if (CurrentCheckpoint == 2) 
		{
			Player.transform.position =  Checkpoint2.transform.position;
		
		}
		if (CurrentCheckpoint == 3) 
		{
			Player.transform.position =  Checkpoint3.transform.position;

		}
	}
}
