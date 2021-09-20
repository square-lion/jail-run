using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool isPaused;
	public GameObject PauseMenuCanvas;

	void Update()
	{
		if (isPaused) {
			PauseMenuCanvas.SetActive (true);
	
		} else {
			PauseMenuCanvas.SetActive (false);
	
		}
		if (Input.GetKeyDown (KeyCode.Escape))
			isPaused = !isPaused;
	}


	public void Resume()
	{
		isPaused = false;
	}
	public void LevelSelect()
	{
		SceneManager.LoadScene(levelSelect);	
	}
	public void MainMenu()
	{
		SceneManager.LoadScene(mainMenu);
	}
}
