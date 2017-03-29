// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/27/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the pin setting

// ----------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;

	private Animator animator;
	private PinCounter pinCount;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
		pinCount = GameObject.FindObjectOfType<PinCounter>();

	}
	
	// Update is called once per frame
	void Update () {

		

	}

	public void RaisePins () {

		foreach (Pin _pin in GameObject.FindObjectsOfType<Pin>()) {

			if (_pin.isStanding()) {

				_pin.Raise();

			}

		}

	}

	public void LowerPins () {

		foreach (Pin _pin in GameObject.FindObjectsOfType<Pin>()) {

			if (_pin.isStanding()) {

				_pin.Lower();

			}

		}

	}

	public void RenewPins () {

		Instantiate (pinSet, new Vector3 (0, 5f, 1829f), Quaternion.identity);

	}

	public void PerformAction (ActionMaster.Action action) {


		if (action == ActionMaster.Action.Tidy) {

			animator.SetTrigger("tidyTrigger");

		} else if (action == ActionMaster.Action.EndTurn) {

			animator.SetTrigger("resetTrigger");
			pinCount.Reset();

		} else if (action == ActionMaster.Action.Reset) {

			animator.SetTrigger("resetTrigger");
			pinCount.Reset();

		} else if (action == ActionMaster.Action.EndGame) {

			throw new UnityException ("Don't know how to end game");

		}

	}

	void OnTriggerExit (Collider _col) {

		GameObject thingLeaving = _col.gameObject;

		if (thingLeaving.GetComponent<Pin>()) {

			Destroy (thingLeaving);

		}

	}

}
