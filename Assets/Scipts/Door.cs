using UnityEngine;
using System.Collections; 
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public string level;
	public string cur;
	public bool alwaysUnlocked;
	private PlayerController player;
	public LSEnd lSEnd;

	private float time;
	void Start()
	{
		player = FindObjectOfType<PlayerController> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.CompareTag("Player"))
		{
			cur = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.IndexOf(" ")+1);
			Debug.Log("Cur" + cur);
		if(alwaysUnlocked)
			{
				if(PlayerPrefs.GetInt("FromLS") == 0)
					SceneManager.LoadScene(level);
				else{
					FindObjectOfType<Timer>().StopTimer();
					if(PlayerPrefs.GetFloat("BestTime" + cur) == 0f || PlayerPrefs.GetFloat("BestTime" + cur) > FindObjectOfType<Timer>().yourTime){
						PlayerPrefs.SetFloat("BestTime" + cur, FindObjectOfType<Timer>().yourTime);
					}
					lSEnd.gameObject.SetActive(true);
				}
			}
		else{
			if(other.GetComponent<PlayerController>().hasKey)
			{
				if(PlayerPrefs.GetInt("FromLS") == 0)
					SceneManager.LoadScene(level);
				else{
					FindObjectOfType<Timer>().StopTimeLS();
					if(PlayerPrefs.GetFloat("BestTime" + cur) == 0f || PlayerPrefs.GetFloat("BestTime" + cur) > FindObjectOfType<Timer>().yourTime){
						PlayerPrefs.SetFloat("BestTime" + cur, FindObjectOfType<Timer>().yourTime);
					}
					lSEnd.gameObject.SetActive(true);
				}
			}
		}
		}
	}
}
