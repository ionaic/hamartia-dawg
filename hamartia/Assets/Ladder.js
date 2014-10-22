var ladderBottom : GameObject;
var ladderTop : GameObject;

public var isFallingLadder : int = 0;
private var climbDirection : Vector3 = Vector3.zero;


function Start () {
	climbDirection = ladderTop.transform.position -  ladderBottom.transform.position;
	Debug.Log("on ladder");
}
/*
function OnTriggerEnter (other : Collider) {
 	//player.SendMessage("PlayerTouchLadder", this.gameobject);
 	Debug.Log("omg ladder");
    other.gameObject.SendMessage("PlayerTouchLadder", this.gameObject, SendMessageOptions.DontRequireReceiver);
}

function OnTriggerExit(other : Collider) {
	Debug.Log("bye ladder");
    // tell controller we give back control
    other.gameObject.SendMessage("PlayerExitLadder", this.gameObject, SendMessageOptions.DontRequireReceiver);
}*/

function ClimbDirection () {
	return climbDirection;
}

function RotateSelf() {
	//rigidbody.isKinematic = false;
	Rotation(transform, Vector3.right * -93.0, 20);
}

function isFalling () {
	return isFallingLadder;
}

function Rotation (thisTransform : Transform, degrees : Vector3, time : float) {
	var startRotation = thisTransform.rotation;
	var endRotation = thisTransform.rotation * Quaternion.Euler(degrees);
	var rate = 1.0/time;
	var t = 0.0;
	while (t < 1.0) {
		t += Time.deltaTime * rate;
		rate = rate+0.05;
		thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
		yield;
	}
}