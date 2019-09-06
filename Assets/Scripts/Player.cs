using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float playerSpeed;
	float maxSpeed;
	Rigidbody playerRb;
	void Start ()
    {
		playerSpeed = 100f;
		maxSpeed = 5f;
		playerRb = GetComponent<Rigidbody> ();
	}
	void Update ()
    {
        Move();
	}
    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
			playerRb.AddForce(Vector3.forward * playerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
			playerRb.AddForce(Vector3.back * playerSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
			playerRb.AddForce(Vector3.left * playerSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
			playerRb.AddForce(Vector3.right * playerSpeed);
        }
		playerRb.velocity = Vector3.ClampMagnitude (playerRb.velocity, maxSpeed);
    }
}
