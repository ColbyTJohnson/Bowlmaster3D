// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/28/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to manage the games structure

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	List<int> bowls = new List<int>();

	private PinSetter pinSet;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {

		pinSet = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	
	}
	
	// Update is called once per frame
	void Update () {

		

	}

	public void Bowl (int pinFall) {

		bowls.Add (pinFall);
		ball.Reset();

		ActionMaster.Action nextAction = ActionMaster.NextAction (bowls);

		pinSet.PerformAction(nextAction);

		try {

			scoreDisplay.FillFrameScores (bowls);
			scoreDisplay.FillFrameCumulatives(ScoreMaster.ScoreCumulative(bowls));

		} catch {

			Debug.LogWarning ("Something went wrong with FillScoreCard()");

		}

	}

}
