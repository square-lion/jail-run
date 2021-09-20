using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MonoBehaviour
{
    float bestTimeF, bestTimeE, bestTimeD, bestTimeC, bestTimeA;
    public Text f,e,d,c,a;
    public Text best;

    void Start(){
        bestTimeF = PlayerPrefs.GetFloat("BestTimeF");
        bestTimeE = PlayerPrefs.GetFloat("BestTimeE");
        bestTimeD = PlayerPrefs.GetFloat("BestTimeD");
        bestTimeC = PlayerPrefs.GetFloat("BestTimeC");
        bestTimeA = PlayerPrefs.GetFloat("BestTimeA");

        if(bestTimeF != 0)
            f.text = "Best Time: " + string.Format("{0}:{1:00.000}", (int)bestTimeF / 60, bestTimeF % 60);
        if(bestTimeE != 0)
            e.text = "Best Time:; " + string.Format("{0}:{1:00.000}", (int)bestTimeE / 60, bestTimeE % 60);
        if(bestTimeD != 0)
            d.text = "Best Time: " + string.Format("{0}:{1:00.000}", (int)bestTimeD / 60, bestTimeD % 60);
        if(bestTimeC != 0)
            c.text = "Best Time: " + string.Format("{0}:{1:00.000}", (int)bestTimeC / 60, bestTimeC % 60);
        if(bestTimeA != 0)
            a.text = "Best Time: " + string.Format("{0}:{1:00.000}", (int)bestTimeA / 60, bestTimeA % 60);
        if (bestTimeA != 0 && bestTimeC != 0 && bestTimeD != 0 && bestTimeF != 0)
            best.text = "Best Possible Time:\n" + string.Format("{0}:{1:00.000}", (int)(bestTimeA + bestTimeC + bestTimeD + bestTimeF+(32.67f))/60, (bestTimeA + bestTimeC + bestTimeD + bestTimeF+(32.67f)) % 60);
    }

    public void Click(int floor){
        switch (floor){
            case 0:SceneManager.LoadScene("Floor F"); break;
            case 1:SceneManager.LoadScene("Floor E"); break;
            case 2:SceneManager.LoadScene("Floor D"); break;
            case 3:SceneManager.LoadScene("Floor C"); break;
            case 4:SceneManager.LoadScene("Floor A"); break;
        }
        FindObjectOfType<Timer>().StartTimer();
        PlayerPrefs.SetInt("FromLS", 1);
    }

    public void Close(){
        PlayerPrefs.SetInt("FromLS", 0);
        FindObjectOfType<MainMenu>().UpdatePreview();
        gameObject.SetActive(false);
    }
}
