using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour 
{
	bool pressed = false;
	//public LoadingScreen LoadScript;
	
	void OnGUI()
	{
		if(!pressed && GUI.Button(new Rect (100,500,150,100), "Start Button"))
		{
			//print ("Start Pressed");
			pressed = true;
			Application.LoadLevel ("Tutorial");
		}
		if(!pressed && GUI.Button(new Rect (774,500,150,100), "Credits"))
		{
			//print ("Start Pressed");
			pressed = true;
			Application.LoadLevel ("Credits");
		}
	}
}