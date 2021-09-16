using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour {

	void Start(){
		if(PlayerPrefs.GetInt("NewGame1") == 0){
			PlayerPrefs.SetInt("NewGame1", 1); 
		} else{
			Destroy(this.gameObject);
		}
	}

	public void NextPage(GameObject page){	
		page.SetActive(false);
	}
}
