// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/27/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to hide and unhide move arrows

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowArrows : MonoBehaviour {

	private Ball ball;
	private Image image;

	void Start () {

		ball = FindObjectOfType<Ball>();
		image = GetComponent<Image>();
		
	}

	void Update () {

		if (ball.inPlay == false) {

			image.enabled = true;

		} else {

			image.enabled = false;

		}

	}

}
