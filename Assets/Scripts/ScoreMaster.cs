// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/28/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to handle the scoring in the frames

// ----------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {

	public static List<int> ScoreCumulative (List<int> _rolls) {

		List<int> cumulativeScores = new List<int>();

		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(_rolls)) {

			runningTotal += frameScore;

			cumulativeScores.Add (runningTotal);

		}

		return cumulativeScores;

	}

	public static List<int> ScoreFrames (List<int> _rolls) {
		
		List<int> frames = new List<int> ();

		// Index i points to second bowl of frame
		for (int i = 1; i < _rolls.Count; i += 2) {

			// Prevents 11th frame score
			if (frames.Count == 10) {

				break;

			}

			// Normal "open" frame
			if (_rolls[i-1] + _rolls[i] < 10) {

				frames.Add (_rolls[i-1] + _rolls[i]);

			}

			// No frames ahead to pull from
			else if (_rolls.Count - i <= 1) {

				break;

			}

			// Strike Bonus
			else if (_rolls[i-1] == 10) {

				// Strike frame has just one bowl, decrement i
				i--;

				frames.Add (10 + _rolls[i+1] + _rolls[i+2]);

			}

			// Spare frame
			else if (_rolls[i-1] + _rolls[i] == 10) {

				frames.Add (10 + _rolls[i+1]);

			}

		}

		return frames;

	}

}
