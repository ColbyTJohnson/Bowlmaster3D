// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/28/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to count pins

// ----------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {

	public Text standingText;

	public bool ballOutOfPlay = false;

	private GameManager gameManager;

	private float lastChangeTime;
	private int lastSettledCount = 10;
	private int lastStandingCount = -1;

	// Use this for initialization
	void Start () {

		gameManager = GameObject.FindObjectOfType<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {

		standingText.text = CountStanding().ToString();

		if (ballOutOfPlay) {

			standingText.color = Color.red;
			CheckStanding();

		}

	}

	public void Reset () {

		lastSettledCount = 10;

	}

	int CountStanding () {

		int standing = 0;

		foreach (Pin _pin in GameObject.FindObjectsOfType<Pin>()) {

			if (_pin.isStanding()) {

				standing++;

			}

		}

		return standing;

	}

	void CheckStanding () {

		int currentStanding = CountStanding();

		if (currentStanding != lastStandingCount) {

			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;

			return;

		}

		float settleTime = 3f;

		if ((Time.time -lastChangeTime) > settleTime) {

			PinsHaveSettled();

		}

	}

	void PinsHaveSettled () {

		int pinFall = lastSettledCount - CountStanding();
		lastSettledCount = CountStanding();

		gameManager.Bowl (pinFall);

		lastStandingCount = -1;
		ballOutOfPlay = false;
		standingText.color = Color.green;	

	}

	void OnTriggerExit (Collider _col) {

		if (_col.name == "Ball") {

			ballOutOfPlay = true;

		}

	}	

}
