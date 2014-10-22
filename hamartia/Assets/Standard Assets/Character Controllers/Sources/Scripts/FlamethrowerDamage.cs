using UnityEngine;
using System.Collections;

public class FlamethrowerDamage : MonoBehaviour
{
	public ParticleEmitter inner;
	public ParticleEmitter outer;
    public Light lightSource;
	// ParticleEmitter smoke;
	bool damaged;
	public DogController dog;

	void Start()
	{
		//inner = transform.Find("flame_group/flame_inner").particleEmitter;
		//outer = transform.Find("flame_group/flame_outer").particleEmitter;
		//lightSource = transform.Find("flame_group/Lightsource").particleEmitter;
        
		//smoke = transform.Find("flame_group/smoke").particleEmitter;
		inner.emit = false;
		outer.emit = false;
        lightSource.active = false;
		//smoke.emit = false;
		
		//dog = GetComponent<DogController>();
        damaged = dog.GetFireDamage();
	}
	
	void Update()
	{
		if (dog.GetFireDamage()) {
            return;
        }
		Debug.Log (damaged);
		if(Input.GetButtonUp("Fire2")) {
			//smoke.emit = false;
			inner.emit = false;
			outer.emit = false;
		}
		else if (Input.GetButtonDown("Fire2")) {
			//smoke.emit = true;
			inner.emit = true;
			outer.emit = true;
		}
	}
}
