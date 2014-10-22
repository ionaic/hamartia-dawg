using UnityEngine;
using System.Collections;

public class DamagedFire : MonoBehaviour
{
	GameObject player;
	bool isOnFire = false;
	bool hasExploded = false;
	ParticleEmitter Shell;
	ParticleEmitter Core;
	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Shell = transform.Find("Explosion/Shell").particleEmitter;
		Core = transform.Find("Explosion/Core").particleEmitter;
		Shell.emit = false;
		Core.emit = false;
	}
	
	void Update () 
	{
		if(!hasExploded && isOnFire)
		{
			hasExploded = true;
			player.SendMessage("SetFireDamage", true, SendMessageOptions.RequireReceiver);
			Explosion();
		}
		Shell.emit = false;
		Core.emit = false;
	}
	
	void OnParticleCollision()
	{
		isOnFire = true;
	}
	
	void Explosion()
	{
		Shell.Emit();
		Core.Emit();
		//Destroy (this);
		Destroy (gameObject, 1.25f);
	}
}
