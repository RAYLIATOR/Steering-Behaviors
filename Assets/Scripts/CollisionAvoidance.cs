using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : Pursue
{
    Vector3 avoidanceForce;
    public float maxAvoidanceForce;
    Vector3 ahead;
    public float maxSeeAhead;
    Vector3 avoidance;
	void Update () 
	{
        Evasion();
        AvoidCollision();
        ApplySteering();
	}
    void AvoidCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxSeeAhead))
        {
            print("collision");
            ahead = transform.position + Vector3.Normalize(enemyRb.velocity) * maxSeeAhead;
            avoidanceForce = ahead - hit.transform.position;
            avoidanceForce = Vector3.Normalize(avoidanceForce) * maxAvoidanceForce;
            steering += avoidanceForce;
        }
        else
        {
            print("clear");
        }
        Debug.DrawRay(transform.position, transform.forward * maxSeeAhead, Color.yellow);
    }
}
