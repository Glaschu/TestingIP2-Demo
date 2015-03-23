using UnityEngine;
using System.Collections;

public class LevelTransitionScript : MonoBehaviour {

	public int Level;

	void Start () 
	{
		Level = -1;
	}

	void Update () 
	{
		//Load Game Hub
		if (Input.GetKey (KeyCode.Return) && Level == 0)
		{
			Application.LoadLevel ("GameHub");
		}
		//Load Level 1
		if (Input.GetKey (KeyCode.Return) && Level == 1)
		{
			Application.LoadLevel ("Level1");
		}
		//Load Level 2
		if (Input.GetKey (KeyCode.Return) && Level == 2)
		{
			Application.LoadLevel ("Level2");
		}
		//Load Level 3
		if (Input.GetKey (KeyCode.Return) && Level == 3)
		{
			Application.LoadLevel ("Level3");
		}
		//Load Level 4
		if (Input.GetKey (KeyCode.Return) && Level == 4)
		{
			Application.LoadLevel ("Level4");
		}
		//Load Level 5
		if (Input.GetKey (KeyCode.Return) && Level == 5)
		{
			Application.LoadLevel ("Level5");
		}
		//Load Level 6
		if (Input.GetKey (KeyCode.Return) && Level == 6)
		{
			Application.LoadLevel ("Level6");
		}
		//Game Complete
		if (Input.GetKey (KeyCode.Return) && Level == 7)
		{
			Application.Quit();
		}
	}
	void OnTriggerEnter2D(Collider2D target)
	{
		//If TutorialComplete
		if (target.gameObject.tag == "TutorialComplete") 
		{
			Level = 0;
		}
		//If Level1 Selected
		else if (target.gameObject.tag == "Level1") 
		{
			Level = 1;
		}
		//If Level1Complete
		else if (target.gameObject.tag == "Level1Complete") 
		{
			Level = 0;
		}
		//If Level2 Selected
		else if (target.gameObject.tag == "Level2") 
		{
			Level = 2;
		}
		//If Level2Complete
		else if (target.gameObject.tag == "Level2Complete") 
		{
			Level = 0;
		}
		//If Level3 Selected
		else if (target.gameObject.tag == "Level3") 
		{
			Level = 3;
		}
		// If Level3Complete
		else if (target.gameObject.tag == "Level3Complete") 
		{
			Level = 0;
		}
		//If Level4 Selected
		else if (target.gameObject.tag == "Level4") 
		{
			Level = 4;
		}
		// If Level4Complete
		else if (target.gameObject.tag == "Level4Complete") 
		{
			Level = 0;
		}
		//If Level5 Selected
		else if (target.gameObject.tag == "Level5") 
		{
			Level = 5;
		}
		// If Level5Complete
		else if (target.gameObject.tag == "Level5Complete") 
		{
			Level = 0;
		}
		//If Level6 Selected
		else if (target.gameObject.tag == "Level6") 
		{
			Level = 6;
		}
		// If Level6Complete
		else if (target.gameObject.tag == "Level6Complete") 
		{
			Level = 7;
		} 

	}
	void OnTriggerExit2D(Collider2D target)
	{
		Level = -1;
	}
}
