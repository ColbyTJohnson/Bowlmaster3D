// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/21/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the ball

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool inPlay;

	private Vector3 ballPos;

	private AudioSource audioSource;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		inPlay = false;
		rigidBody.useGravity = false;

		ballPos = transform.position;

	}

	public void LaunchBall (Vector3 _velocity) {

		inPlay = true;
		rigidBody.useGravity = true;

		rigidBody.velocity = _velocity;
		audioSource.Play ();

	}
	
	public void Reset () {

		inPlay = false;
		transform.position = ballPos;
		transform.rotation = Quaternion.identity;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;

	}

}
