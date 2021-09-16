using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LSEnd : MonoBehaviour
{
    public Door door;

    public Text time;
    public Text bestTime;

    void OnEnable(){
        time.text = "Time - " + string.Format("{0}:{1:00.000}", (int)FindObjectOfType<Timer>().yourTime / 60, FindObjectOfType<Timer>().yourTime % 60);
        bestTime.text = "Best Time- " + string.Format("{0}:{1:00.000}", (int)PlayerPrefs.GetFloat("BestTime" + door.cur) / 60, PlayerPrefs.GetFloat("BestTime" + door.cur) % 60);
    }

    public void Retry(){
        FindObjectOfType<Timer>().StopTimeLS();
        FindObjectOfType<Timer>().StartTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LS(){
        SceneManager.LoadScene("Menu");
    }
    public void Menu(){
        PlayerPrefs.SetInt("FromLS", 0);
        SceneManager.LoadScene("Menu");
    }
}
