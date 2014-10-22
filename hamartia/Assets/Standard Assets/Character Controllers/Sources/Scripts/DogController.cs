using UnityEngine;
using System.Collections;

public class DogController : MonoBehaviour 
{
	//If a part is damaged the bool is set to true
	public bool JumpDamaged = false; //Jumping
	public bool PickupDamaged = false; //Picking up things
	public bool FireDamaged = false; //Flamethrower
	public bool ClimbDamaged = false; //Climbing
	
	public void SetJumpDamage(bool state)
	{
		JumpDamaged = state;
	}
	
	public bool GetJumpDamage()
	{
		return JumpDamaged;
	}
	
	public void SetClimbDamage(bool state)
	{
		ClimbDamaged = state;
	}
	
	public bool GetClimbDamage()
	{
		return ClimbDamaged;
	}
	
	public void SetPickupDamage(bool state)
	{
		PickupDamaged = state;
	}
	
	public bool GetPickupDamage()
	{
		return PickupDamaged;
	}
	
	public void SetFireDamage(bool state)
	{
		FireDamaged = state;
	}
	
	public bool GetFireDamage()
	{
		return FireDamaged;
	}
}
