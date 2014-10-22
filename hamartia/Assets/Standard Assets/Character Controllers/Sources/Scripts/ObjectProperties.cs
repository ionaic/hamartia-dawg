using UnityEngine;
using System.Collections;

public class ObjectProperties : MonoBehaviour {
	private GameObject player;

	void Start () {
		this.player = GameObject.FindWithTag("Player");
	}

	// handle OnTriggerEnter for this object (object in range)
	void OnTriggerEnter(Collider otherObj) {
		if (otherObj.tag == "hand") {
			this.player.SendMessage("AreWeInRange", true);
			this.player.SendMessage("IDobj", this.gameObject);
			//this.inRange = true;
			//Debug.Log ("Enter; Player is: " + this.player.tag);
		}
	}
	
	// handle OnTriggerExit for this object (object out of range)
	void OnTriggerExit(Collider otherObj) {
		if (otherObj.tag == "hand") {
			this.player.SendMessage ("AreWeInRange", false);
			//Debug.Log ("Exit; Player is: " + this.player);
			//this.inRange = false;
			//this.player.SendMessage ("IDobj", this.gameObject);
		}
	}
}
