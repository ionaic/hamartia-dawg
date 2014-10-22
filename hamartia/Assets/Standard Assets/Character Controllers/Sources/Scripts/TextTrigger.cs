using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {
	
	private bool played = false;
	private MenuSystem someScript;
	GameObject player;
	public int message;
	public bool isReplayable = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("MainCamera");

	}
	
	void OnTriggerEnter(Collider obj)
	{
		if(!played && obj.gameObject.CompareTag("Player"))
		{
			someScript = player.GetComponent<MenuSystem>();
			someScript.AddMessage(message);
			if(!isReplayable)
			{
				played = true;
			}
		}
	}
}
