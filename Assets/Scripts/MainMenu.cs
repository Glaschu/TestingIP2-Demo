using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	void Start()
	{

	}
	void Update() 
	{

	}

	public void NewGame ()
	{
		Application.LoadLevel ("Tutorial");
	}

	public void LoadGame ()
	{

	}

	public void ViewCredits ()
	{

	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}