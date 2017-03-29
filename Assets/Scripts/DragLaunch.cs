// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/27/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the input for launching the ball

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	public float minVel;

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	private Ball ball;

	// Use this for initialization
	void Start () {

		ball = GetComponent<Ball>();

	}

	public void MoveStart (float _amount) {

		if (!ball.inPlay) {

			float xPos = Mathf.Clamp(ball.transform.position.x + _amount, -50f, 50f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;


			ball.transform.position = new Vector3 (xPos, yPos, zPos);

		}
	}

	public void DragStart () {

		if (!ball.inPlay) {

			// Capture time and position of mouse click

			dragStart = Input.mousePosition;

			startTime = Time.time;

		}

	}	

	public void DragEnd () {

		if (!ball.inPlay) {

			// Capture time and position of mouse release

			dragEnd = Input.mousePosition;

			endTime = Time.time;
				
			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ); 

			if (launchSpeedZ < minVel) {

				ball.LaunchBall (new Vector3 (launchSpeedX, 0, minVel));

			} else {

				ball.LaunchBall (launchVelocity);

			}

		}

	}

}
