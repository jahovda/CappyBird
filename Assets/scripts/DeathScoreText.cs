using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DeathScoreText : MonoBehaviour
{
	Text score;

	void OnEnable() {
		score = GetComponent<Text>();
		score.text = "PLAYER: " + PlayerPrefs.GetString("username") + Environment.NewLine + Environment.NewLine + "SCORE: " +PlayerPrefs.GetString("score");
	}
}


