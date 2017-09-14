using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {
	
	public Text scoreText;

	private float TimeStart;
	private bool active;
	private int score;
	private int highScore;

	void Start()
	{
		active = false;
		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore", highScore);
		displayScores ();
	}

	void Update() {
		if (active)
		{
			score = Mathf.RoundToInt(Time.time - TimeStart);
			scoreText.text = score.ToString();
		}
	}

	public void StartScoreTracking()
	{
		TimeStart = Time.time;
		active = true;
	}

	public void StopScoreTracking()
	{
		active = false;
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("highScore", highScore);
			PlayerPrefs.Save ();
		}
		highScore = Mathf.Max (score, highScore);
		displayScores ();
	}

	void displayScores () {
		scoreText.text = "High: " + highScore + ", Last: " + score;
	}
}
