// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/28/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the gutterballs

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour {

	private PinCounter pinCount;

	// Use this for initialization
	void Start () {

		pinCount = GameObject.FindObjectOfType<PinCounter>();

	}

}
