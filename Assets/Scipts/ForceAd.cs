using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class ForceAd : MonoBehaviour 
{
    void Start (){
        #if UNITY_IPHONE
            Advertisement.Initialize ("1743714", false);
        #endif
        #if UNITY_ANDROID
            Advertisement.Initialize ("1743713", false);
        #endif
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show ();
		yield return new WaitForSeconds(5f);
    }
	public void ShowAd(){
		if(!Advertisement.IsReady()){
			return;
		}
		else if (PlayerPrefs.GetInt("PlayAds") == 0){
			Advertisement.Show();
		}
	}
}