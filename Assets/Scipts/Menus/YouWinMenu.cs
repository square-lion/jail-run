using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class YouWinMenu : MonoBehaviour {
	 
	public string levelSelect;
	public string mainMenu;
	public string CurrentLevel;
	public bool winner;

	public GameObject WinnerMenuCanvas;
	// Use this for initialization
	void Start () {
		WinnerMenuCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


		if (GameObject.Find ("Boss")) {
			winner = false;
		} 
		if (winner) {
			WinnerMenuCanvas.SetActive (true);
		}
	}
	public void Retry()
	{
		SceneManager.LoadScene(CurrentLevel);
	}
	public void LevelSelect()
	{
		SceneManager.LoadScene(levelSelect);
	}
	public void Quit()
	{
		SceneManager.LoadScene(mainMenu);
	}

}
