// -------------------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/28/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A script to test the scoremaster

// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class OurScoreDisplayTest {
	
	[Test]
	public void T00_PassingTest () {

		Assert.AreEqual (1, 1);

	}

	[Test]
	public void T01_Bowl1 () {

		int[] rolls = {1};
		string rollsString = "1";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

	[Test]
	public void T02_X () {

		int[] rolls = {10};
		string rollsString = "X ";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

	[Test]
	public void T03_19 () {

		int[] rolls = {1,9};
		string rollsString = "1/";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

	[Test]
	public void T04_191 () {

		int[] rolls = {1,9, 1};
		string rollsString = "1/1";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

	[Test]
	public void T04_SpareInLastFrame () {

		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,1};
		string rollsString = "1111111111111111111/1";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

	[Test]
	public void T05_StrikeInLastFrame () {

		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
		string rollsString = "111111111111111111X11";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

	[Test]
	public void T06_0 () {

		int[] rolls = {0};
		string rollsString = "-";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));

	}

}