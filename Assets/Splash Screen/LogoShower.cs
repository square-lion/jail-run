using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoShower : MonoBehaviour{

    public string nextScene;

    public AudioSource jackBMusic;
    public AudioSource squarelion;

    void Start(){
        PlayerPrefs.SetInt("FromLS", 0);

        StartCoroutine("ShowLogos");
    }

    public void SquareLionAudio(){
        squarelion.Play();
    }
    public void JackBMusicAudio(){
        jackBMusic.Play();
    }
    public void End(){
        SceneManager.LoadScene(nextScene);
    }
}
