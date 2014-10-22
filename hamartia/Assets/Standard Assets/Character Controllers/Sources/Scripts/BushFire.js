public var inner: ParticleEmitter;
public var outer: ParticleEmitter;
var onFire = false;

var colorStart : Color;
var colorEnd : Color = Color.black;
var duration : float = 1.0;

function Start(){
	inner = transform.Find("flame_group/flame_inner").particleEmitter;
	outer = transform.Find("flame_group/flame_outer").particleEmitter;
	inner.emit = false;
	outer.emit = false;
	colorStart = renderer.material.GetColor("_Color");
}

function Update () {

	if(onFire)
	{
	  inner.emit = true;
	  outer.emit = true;
	  var lerp : float = Mathf.PingPong (Time.time, duration) / duration;
      renderer.material.color = Color.Lerp (colorStart, colorEnd, lerp);
      colorStart = Color.black;
      Destroy(gameObject, 5);
	}
	else{
	  inner.emit = false;
	  outer.emit = false;
	}

}

function OnParticleCollision () {
    //Debug.Log ("Hello");
	onFire = true;
}
