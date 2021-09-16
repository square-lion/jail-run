using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	private bool InZone;

	public string LevelToLoad;

	 
	// Use this for initialization
	void Start () {
		InZone = false;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) & InZone)
			{
				SceneManager.LoadScene(LevelToLoad);
			}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			InZone = true;
		}
			
	}
	void OnTriggerExitr2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			InZone = false;
		}

	}
}
