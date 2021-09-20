using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {


	public float yourTime;
	public bool timing;

	public AudioSource run;
	public AudioSource caught;
	public AudioSource warden;
	public AudioSource win;

	

	void Start () {
		if(FindObjectOfType<Timer>() == null)
			Destroy(this);
		else
			DontDestroyOnLoad(gameObject);
	}
	

	void Update () {
		if(timing)
			yourTime += Time.deltaTime;

		if(SceneManager.GetActiveScene().name == "Floor A" && !warden.isPlaying && timing){
			warden.Play();
			caught.Stop();
			run.Stop();
		}
		else if(SceneManager.GetActiveScene().name == "Floor B" && !caught.isPlaying){
			caught.Play();
			run.Stop();
		}
		else if(SceneManager.GetActiveScene().name == "Game Over" && warden.isPlaying)
			warden.Stop();
		else if(SceneManager.GetActiveScene().name == "Menu"){
			warden.Stop();
			caught.Stop();
			run.Stop();
			win.Stop();
		}		
		else if(!run.isPlaying && timing){
			run.Play();
			win.Stop();
		}
		else if(!timing && !win.isPlaying){
			//win.Play();
		}
		if(SceneManager.GetActiveScene().name == "Floor A" || SceneManager.GetActiveScene().name == "Floor B" || SceneManager.GetActiveScene().name == "Floor A CutScene" || SceneManager.GetActiveScene().name == "Game Over" || SceneManager.GetActiveScene().name == "End Credits")
			run.Stop();
	}
	public void StartTimer()
	{
		timing = true;
		yourTime = 0f;
		run.Play();
	}
	public void StopTimer()
	{
		timing = false;
		warden.Stop();
		run.Stop();
		caught.Stop();
	}

	public void StopTimeLS(){
		timing = false;
		warden.Stop();
		run.Stop();
		caught.Stop();
		//win.Play();
	}
}
