using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour 
{
	public TextAsset[] Blocks;
	
	private Rect defaultRect = new Rect (312, 125, 400, 40);// Assumes a 1024 by 800 display
	
	private ArrayList StoryBlocks = new ArrayList();// Stores all of the lines of the story. 
	private ArrayList Display = new ArrayList();// Stores what lines should be displayed at the time.
	private float timeMarker = 0;// Counter for length messages are on screen. When set to 0, no messages are on screen.
	
	private bool IsPaused = false;
	
	/*public bool Jump = false;
	public bool Climb = false;
	public bool Fire = false;
	public bool Pickup = false;
	GameObject player;*/
	
	void Start ()
	{
		/*player = GameObject.FindGameObjectWithTag("Player");
		player.SendMessage("SetJumpDamage()", Jump);
		player.SendMessage("SetClimbDamage()", Climb);
		player.SendMessage("SetFireDamage()", Fire);
		player.SendMessage("SetPickupDamage()", Pickup);*/
		
		IsPaused = false;
		foreach(TextAsset temp in Blocks)
		{
			//Reads text asset and stores it in the StoryBlocks array.
			ArrayList Lines = new ArrayList();
			string[] dataLines = temp.text.Split('\n');
			foreach (string line in dataLines)
	        {
				Lines.Add (line);
	        }
			StoryBlocks.Add(Lines);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Display.Count == 0)
		{
			timeMarker = 0;
		}
		
		else if(Display.Count > 0 && timeMarker == 0)
		{
			timeMarker = Time.time;
		}
		
		else if(Display.Count > 0 && Time.time - timeMarker > 5)//Input.GetKeyDown("r"))
		{
			Display.RemoveAt(0);
			Display.TrimToSize();
			timeMarker = 0;
		}
		if(Application.loadedLevelName != "StartMenu" && Application.loadedLevelName != "Credits")
		{
			if(Input.GetKeyDown("escape") && !IsPaused)
			{
				Time.timeScale = 0.0f;
				IsPaused = true;
				print ("Paused");
			}
			else if(Input.GetKeyDown("escape") && IsPaused)
			{
				Time.timeScale = 1.0f;
				IsPaused = false;
				print ("Unpaused");
			}
		}
	}
	
	void OnGUI()
	{
		//If there is a line to be displayed
		if(Display.Count > 0)
		{
			//Debug.Log (Display.Count);
			//Creates and displays the textbox for the current set of lines
			string TextAreaString = "";
			int temp = (int)Display[0];
			//ArrayList temp2 = (ArrayList)StoryBlocks[temp];
			//Debug.Log (StoryBlocks[temp].Count);
			foreach(string line in (ArrayList)StoryBlocks[temp])
			{
				if(TextAreaString == "")
				{
					TextAreaString = TextAreaString + line;
				}
				else
				{
					TextAreaString = TextAreaString + "\n" + line;
				}
			}
			GUI.Label (defaultRect, TextAreaString, "textfield");
		}
		
		//Pause Menu
		if(Application.isLoadingLevel)
		{
			//print ("LOADING");
			GUI.Label(new Rect (200,200,100,100), "Loading...");
		}
		if(IsPaused && GUI.Button(new Rect (440,500,150,100), "Start Menu"))
		{
			Application.LoadLevel("StartMenu");
		}
		if(IsPaused && GUI.Button(new Rect (440,300,150,100), "Resume"))
		{
			IsPaused = false;
			Time.timeScale = 1.0f;
		}
		if(IsPaused && GUI.Button(new Rect (650,400,150,100), "Exit"))
		{
			Application.Quit();
		}
		if(IsPaused && GUI.Button(new Rect (230,400,150,100), "Tutorial Level"))
		{
			//Application.LoadLevel("Tutorial");
		}
		if(IsPaused && GUI.Button(new Rect (100,100,100,75), "Level 1"))
		{
			//Application.LoadLevel("Level1");
		}
		if(IsPaused && GUI.Button(new Rect (350,100,100,75), "Level 2"))
		{
			//Application.LoadLevel("Level2");
		}
		if(IsPaused && GUI.Button(new Rect (600,100,100,75), "Level 3"))
		{
			//Application.LoadLevel("Level3");
		}
		if(IsPaused && GUI.Button(new Rect (850,100,100,75), "Level 4"))
		{
			//Application.LoadLevel("Level4");
		}
	}
	
	public void AddMessage(int input) //Other objects should call this function when they want to add a specific
	{				  		   //message to the display queue. Input is a number corresponding to it's storage location in StoryBlocks.
		Display.Add (input);
	}
	
	public bool GetPaused()
	{
		return IsPaused;	
	}
}
