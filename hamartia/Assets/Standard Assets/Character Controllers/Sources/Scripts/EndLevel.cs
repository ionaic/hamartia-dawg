using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	
	private bool played = false;
	private MenuSystem someScript;
	GameObject player;
	public int message;
	private float endTimer = 0;
	
	public string LevelName ="My level name";
	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("GameController");
	}
	
	void Update()
	{
		if(endTimer != 0 && Time.time - endTimer > 7)
		{
			Application.LoadLevel(LevelName);
		}
	}
	
	void OnTriggerEnter(Collider obj)
	{
		if(!played && obj.gameObject.CompareTag("Player"))
		{
			someScript = player.GetComponent<MenuSystem>();
			someScript.AddMessage(message);
			played = true;
			endTimer = Time.time;
		}
	}
}