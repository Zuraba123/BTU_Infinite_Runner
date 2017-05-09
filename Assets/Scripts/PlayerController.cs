using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody myBody;
	public float maxSpeed;
	public float moveAcceleration;
	public float jumpAcceleration;
	private bool isGrounded = false;

	void FixedUpdate ()
	{
		ConstantMove ();
	}

	void Update()
	{
		if (isGrounded && Input.GetKeyDown (KeyCode.Space))
		{
			Jump ();
		}
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		isGrounded = true;
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		isGrounded = false;
	}

	/// <summary>
	/// this function moves the ball on z axis
	/// </summary>
	void ConstantMove()
	{
		Vector3 newVelocity = myBody.velocity;

		//don't move with higher speed than maxSpeed
		if (newVelocity.z >= maxSpeed)
		{
			newVelocity.z = maxSpeed;
		}

		//accelerate to max speed
		else
		{
			newVelocity.z = newVelocity.z + moveAcceleration;
		}

		myBody.velocity = newVelocity;
	}

	/// <summary>
	/// makes the player jump
	/// </summary>
	void Jump()
	{
		Vector3 jumpVelocity = myBody.velocity;
		jumpVelocity.y = jumpVelocity.y + jumpAcceleration;
		myBody.velocity = jumpVelocity;
	}
}
