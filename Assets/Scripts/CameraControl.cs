// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/21/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the movement of the camera

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Ball ball;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		 ball = GameObject.FindObjectOfType<Ball>();

		 offset = transform.position - ball.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (ball.transform.position.z <= 1750f) {

			transform.position = ball.transform.position + offset;

		}

	}
}
