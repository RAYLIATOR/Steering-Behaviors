using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour 
{
	protected Transform target;
	protected Rigidbody enemyRb;
	public float maxForce;
	public float maxSpeed;
	protected Vector3 desiredVelocity;
	protected Vector3 steering;
	protected virtual void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		enemyRb = GetComponent<Rigidbody> ();
	}
	void Update () 
	{
		_Seek (target.transform.position);
        ApplySteering();
	}
	protected Vector3 _Seek(Vector3 pos)
	{
		//transform.position = transform.position + enemyRb.velocity;
		//enemyRb.velocity = Vector3.Normalize(t.transform.position - transform.position) * maxSpeed;
		desiredVelocity = Vector3.Normalize( pos- transform.position) * maxSpeed;

		steering = desiredVelocity - enemyRb.velocity;
        //transform.position = transform.position + enemyRb.velocity;
        return steering;
	}
	protected Vector3 Flee(Vector3 pos)
	{
		//transform.position = transform.position + enemyRb.velocity;
		//enemyRb.velocity = Vector3.Normalize(t.transform.position - transform.position) * maxSpeed;
		desiredVelocity = Vector3.Normalize( transform.position - pos) * maxSpeed;

		steering = desiredVelocity - enemyRb.velocity;
		//transform.position = transform.position + enemyRb.velocity;
		return steering;
	}

    public void ApplySteering( )
    {
        steering = Vector3.ClampMagnitude(steering, maxForce);
        enemyRb.AddForce(steering);
        enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, maxSpeed);
    }

}
