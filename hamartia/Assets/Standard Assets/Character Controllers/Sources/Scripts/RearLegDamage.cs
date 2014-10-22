using UnityEngine;
using System.Collections;

public class RearLegDamage : MonoBehaviour
{
	ParticleEmitter inner;
	ParticleEmitter outer;
	bool damaged;
	DogController dog;

	void Start()
	{
		inner = transform.Find("Sparkles/sparkle").particleEmitter;
		outer = transform.Find("Sparkles/sparkle2").particleEmitter;
	     
		dog = GetComponent<DogController>();
        damaged = dog.GetJumpDamage();
	}
	
	void Update()
	{
		damaged = dog.GetJumpDamage();
		if(damaged)
		{
			inner.emit = true;
			outer.emit = true;
		}
		else
		{
			inner.emit = false;
			outer.emit = false;
		}
	}
}