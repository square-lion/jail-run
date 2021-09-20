using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {


	public Text scores;
	Highscores highscoreManager;

	public InputField username;
	public Text feedbackText;
	public Text nameText;

	public GameObject noTimeText;

	public List<string> usernames;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetFloat("BestTime", 63.124f);
		 
		scores.text = "Fetching...";			
		highscoreManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");

		if(noTimeText != null)
			noTimeText.SetActive(false);

		if(PlayerPrefs.GetString("Username") != ""){
			if(username != null)
				username.gameObject.SetActive(false);
			Debug.Log("Sending Score");
			highscoreManager.AddNewHighscore(PlayerPrefs.GetString("Username"), PlayerPrefs.GetFloat("BestTime"));
			nameText.text = "Name: " + PlayerPrefs.GetString("Username");
		}
		else{
			if((username != null && PlayerPrefs.GetFloat("BestTime") > 0) || noTimeText == null){
				username.gameObject.SetActive(true);
			}else{
				noTimeText.SetActive(true);
				username.gameObject.SetActive(false);
			}
		}
	}

	public void OnHighscoresDownloaded(Highscore[] highscoreList)
	{
		scores.text = "";
		bool displayed = false;
		for(int i = 0; i < highscoreList.Length; i++)
		{

			if(i < 9)
				scores.text += (i+1) + ". " + highscoreList[i].username.PadRight(18) + String.Format("{0:#,##0.000;(#,##0.000);Zero}", highscoreList[i].time) + " sec\n";
			else if(i == 9)
				scores.text += (i+1) + "." + highscoreList[i].username.PadRight(18) + String.Format("{0:#,##0.000;(#,##0.000);Zero}", highscoreList[i].time) + " sec\n";
			else if(!displayed){
				if(highscoreList[i].username.Equals(PlayerPrefs.GetString("Username"))){
					scores.text += (i+1) + "." + highscoreList[i].username.PadRight(18) + String.Format("{0:#,##0.000;(#,##0.000);Zero}", highscoreList[i].time) + " sec\n";
				}
			}

			if(highscoreList[i].username.Equals(PlayerPrefs.GetString("Username"))){
				displayed = true;
			}

			usernames.Add(highscoreList[i].username.ToString());
		}
	}

	public void OnHighscoresFailed(){
		scores.text = "No Connection";
	}

	IEnumerator RefreshHighscores()
	{
		while(true)
		{
			highscoreManager.DownloadHighscores();
			yield return new WaitForSeconds(10f); 
		}
	}

	public void Submit(){
		print(username.text);

		if(username.text.ToString() == "")
			feedbackText.text = "Enter username";
		else if(usernames.IndexOf(username.text.ToString()) != -1)
			feedbackText.text = "Username taken";
		else{
			print(highscoreManager);
			FindObjectOfType<Highscores>().AddNewHighscore(username.text, PlayerPrefs.GetFloat("BestTime"));
			PlayerPrefs.SetString("Username", username.text);
			Debug.Log(username.text);
			nameText.text = "Name: " +PlayerPrefs.GetString("Username");
			username.gameObject.SetActive(false);
		}	
	}
}
