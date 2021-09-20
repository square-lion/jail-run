using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCredits : MonoBehaviour {

	public Text timeText;
	public Text lowerTime;
	public string time;
	private float yourTime;
	private float bestTime;
	private string theBestTime;

	public GameObject banner;

	public GameObject leaderboard;

	void Awake () {
		if(PlayerPrefs.GetFloat("BestTime") != 0)
			bestTime = PlayerPrefs.GetFloat("BestTime");
		else
			bestTime = 999999999999;

		theBestTime = "PB: " + string.Format("{0}:{1:00.000}", (int)bestTime / 60, bestTime % 60);
		FindObjectOfType<Timer>().StopTimer();
		yourTime = FindObjectOfType<Timer>().yourTime;
		time = "Time: " + string.Format("{0}:{1:00.000}", (int)yourTime / 60, yourTime % 60);
		timeText.text = time;
		
		if(yourTime < bestTime)
		{
			PlayerPrefs.SetFloat("BestTime", yourTime);
			theBestTime = string.Format("{0}:{1:00.000}", (int)yourTime / 60, yourTime % 60);
			banner.SetActive(true);
		}
		else{
			banner.SetActive(false);
		}
		
		lowerTime.text = theBestTime;
		FindObjectOfType<Timer>().yourTime = 0;
	}

	public void LeaderboardButton(){
		leaderboard.SetActive(!leaderboard.activeSelf);
	}
}
