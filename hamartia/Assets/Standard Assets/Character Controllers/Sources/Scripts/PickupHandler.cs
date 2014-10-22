using UnityEngine;
using System.Collections;

public class PickupHandler : MonoBehaviour {
	// player's hand is labelled with the "hand" tag
	// 	currently made the dog's "mouth" area (empty Game Obj)
	//	the "hand"
	public GameObject dawgMouth;
	
	public Vector3 noseDistance = new Vector3(0f, 0f, 0f);
	
	public float timeThreshold = 0.0001f;
	
	// flag for if the object is within range
	private bool withinRange;
	
	// flag to test if we're already carrying something
	private bool carrying;
	
	// object we're picking up
	private GameObject boulder;
	
	private bool isDamaged = false;
	DogController dog;
	
	// store the time
	//private float lastTime;
	//private float dT;
	
	// Use this for initialization
	void Start () {
		dog = GetComponent<DogController>();
		
		if (!this.dawgMouth) {
			// find the dawg's mouth
			this.dawgMouth = GameObject.FindWithTag("hand");
		}
		// initialize flag that tests if object is within range
		this.withinRange = false;
		// initialize flag that tests if we're carrying something
		this.carrying = false;
		//this.lastTime = Time.time;
	}
	
	// receive messages from OnTriggerEnter events
	public void AreWeInRange(bool withinRange) {
		this.withinRange = withinRange;	
	}
	
	// receive messages identifying which object is in range
	public void IDobj(GameObject obj) {
		if (!this.carrying) {
			this.boulder = obj;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		// update the dT
		//this.dT = Time.time - this.lastTime;
		isDamaged = dog.GetPickupDamage();
		//Debug.Log (isDamaged);
		if(!isDamaged){
			if (Input.GetButtonUp("Fire1") && this.carrying) {
				// if carrying something, drop it
				DropObject();
			}
			else if (Input.GetButtonDown("Fire1") && this.withinRange) {
				if (!this.carrying) {
					// otherwise, if we're in range of an object
					GrabObject();
				}
			}
		}
		else if(this.carrying){
			DropObject ();
		}
	}
	
	void DropObject() {
		if (Time.deltaTime <= 0.001) {
			Debug.Log ("Skipped because of time! " + Time.deltaTime);
			return;
		}
		
		Debug.Log("DropObject");
		// set parent to null so it free floats in scene
		this.boulder.transform.parent = null;
		if (this.boulder.rigidbody) {
			// make it affected by physics again...
			this.boulder.rigidbody.isKinematic = false;
		}
		this.carrying = false;
	}
	
	void GrabObject() {
		Debug.Log("Grab Object");
		if (this.boulder.rigidbody) {
			// make the boulder not affect by physics
			this.boulder.rigidbody.isKinematic = true;
		}
		
		if (this.dawgMouth) {
			// set the parent to the dawg's mouth so they move together
			this.boulder.transform.parent = this.dawgMouth.transform;
			
			// set the position to the position of the dawg's mouth
			//this.boulder.transform.position = this.dawgMouth.transform.position + this.noseDistance;
			this.boulder.transform.localPosition = new Vector3(0, 0, 0);
			Debug.Log("NosePos: " + this.dawgMouth.transform.position);
			Debug.Log("boulderPos: " + this.boulder.transform.position);
			
			// flag that we're carrying something now
			this.carrying = true;
			//this.lastTime = Time.time;
		}
	}
}
