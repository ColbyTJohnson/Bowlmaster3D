// ----------------------------------------------------------------------------------

// Author: Colby Johnson

// Project: Bowlmaster3D

// Last Updated: 07/29/2016

// Credit: Ben Tristem - Learn to Code by Making Games in Unity3D

// Purpose: A class to display the correct scores in each frame

// ----------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] frameCumulative;
	public Text[] frameScore;

	public void FillFrameScores (List<int> _rolls) {

		string scoresString = FormatRolls(_rolls);

		for (int i = 0; i < scoresString.Length; i++) {

			frameScore[i].text = scoresString[i].ToString();

		}

	}

	public void FillFrameCumulatives (List<int> _frames) {

		for (int i = 0; i < _frames.Count; i++) {

			frameCumulative[i].text =  _frames[i].ToString();

		}

	}

	public static string FormatRolls (List<int> _rolls) {

		string output = "";

		for (int i = 0; i < _rolls.Count; i++) {

			int roll = output.Length + 1;

			// In the case of a zero
			if (_rolls[i] == 0) {

				output += "-";

			}

			// In the case of a spare
			else if ((roll % 2 == 0 || roll == 21) && _rolls[i-1] + _rolls[i] == 10) {

				output += "/";

			}

			// In the case of a strike in the last frame
			else if (roll >= 19 && _rolls[i] == 10) {

				output += "X";

			}

			// In the case of a strike (remember space for following frame)
			else if (_rolls[i] == 10) {

				output += "X ";

			} else {

				output += _rolls[i].ToString();

			}

		}

		return output;

	}

}
