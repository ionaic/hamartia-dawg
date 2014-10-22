using UnityEngine;
using System.Collections;

public class LadderTestCollision : MonoBehaviour {
	GameObject player;
	bool onLadder;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter()
	{
		player.SendMessage("SetLadder", true, SendMessageOptions.RequireReceiver);
	}
	void OnTriggerExit()
	{
		player.SendMessage("SetLadder", false, SendMessageOptions.RequireReceiver);
	}
}
