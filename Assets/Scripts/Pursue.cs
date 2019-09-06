using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Seek
{
    Rigidbody playerRb;
	protected override void Start ()
	{
		base.Start ();
		playerRb = target.GetComponent<Rigidbody> ();
    }
	void Update ()
    {
		//Pursuit ();
		Evasion();
        ApplySteering();
	}
	protected void Pursuit()
	{
        transform.LookAt(target);
		int step = 3;
		Vector3 futurePosition = target.transform.position + playerRb.velocity * step;
		_Seek (futurePosition);
	}
	protected void Evasion()
	{
		transform.LookAt(target);
		int step = 3;
		Vector3 futurePosition = (target.transform.position + playerRb.velocity * step);
		Flee (futurePosition);
	}
	}
