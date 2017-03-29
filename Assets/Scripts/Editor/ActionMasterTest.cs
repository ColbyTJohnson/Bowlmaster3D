// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/28/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to test the actionmaster script

// ----------------------------------------------------------------------------------

using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

[TestFixture]

public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void SetUp () {

		pinFalls = new List<int>();

	}

	[Test]
	public void T00_PassingTest () {

		Assert.AreEqual (1, 1);

	}

	[Test]
	public void T01_FirstThrowStrike () {

		pinFalls.Add(10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));

	}

	[Test]
	public void T02_FirstThrow8 () {

		pinFalls.Add(8);
		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));

	}

	[Test]
	public void T03_Bowl2Bowl8 () {

		int[] rolls = {2, 8};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test] 
	public void T04_StrikeInLastFrame () {

		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));

	}

	[Test] 
	public void T05_SpareInLastFrame () {

		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9};
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));

	}

	[Test]
	public void T06_YouTubeRolls () {

		int[] rolls = {8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));

	}

	[Test] 
	public void T07_EndGameOn20 () {

		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));

	}

	[Test] 
	public void T08_StrikeInLastFrameFirstRoll () {

		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5};
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));

	}

	[Test] 
	public void T09_TurkeyLastFrame () {

		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));

	}

}