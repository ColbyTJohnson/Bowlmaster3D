// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/27/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the pins

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;
	public float raiseHeight = 50f;

	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isStanding () {

		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {

			return true;

		} else {

			return false;

		}

	}

	public void Raise () {

		if (isStanding()) {

			rigidbody.useGravity = false;
			transform.Translate (new Vector3 (0, raiseHeight, 0), Space.World);
			transform.rotation = Quaternion.Euler (270f, 0, 0);

		}

	}

	public void Lower () {

		if (isStanding()) {

			transform.Translate (new Vector3 (0, -raiseHeight, 0), Space.World);
			rigidbody.useGravity = true;

		}

	}

}
