using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShopMenu : MonoBehaviour{

    CharacterCustomizationMenu characterCustomizationMenu;

    public GameObject item5Cover;
    public GameObject removeAds;
    public GameObject watchAds;

    void Awake(){
        characterCustomizationMenu = FindObjectOfType<CharacterCustomizationMenu>();
    }
    
    void Start (){
        #if UNITY_IPHONE
            Advertisement.Initialize ("1743714", false);
        #endif
        #if UNITY_ANDROID
            Advertisement.Initialize ("1743713", false);
        #endif

        if(PlayerPrefs.GetInt("PlayAds") == 1){
            removeAds.SetActive(true);
        }
        if(characterCustomizationMenu.outfitsLeft + characterCustomizationMenu.footwearLeft + characterCustomizationMenu.headwearLeft + characterCustomizationMenu.tHeadwearLeft + characterCustomizationMenu.hairLeft + characterCustomizationMenu.facialHairLeft < 5){
            item5Cover.SetActive(true);
        }
        if(characterCustomizationMenu.outfitsLeft + characterCustomizationMenu.footwearLeft + characterCustomizationMenu.headwearLeft + characterCustomizationMenu.tHeadwearLeft + characterCustomizationMenu.hairLeft + characterCustomizationMenu.facialHairLeft == 0){
            watchAds.SetActive(true);
        }
    }

    public void ShowRewardedVideo (){
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("rewardedVideo", options);
    }

    void HandleShowResult (ShowResult result){
        if(result == ShowResult.Finished) {
            characterCustomizationMenu.OneRandomItem();

            if(characterCustomizationMenu.outfitsLeft + characterCustomizationMenu.footwearLeft + characterCustomizationMenu.headwearLeft + characterCustomizationMenu.tHeadwearLeft + characterCustomizationMenu.hairLeft + characterCustomizationMenu.facialHairLeft == 0){
                watchAds.SetActive(true);
        }

        }else if(result == ShowResult.Skipped) {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }else if(result == ShowResult.Failed) {
            Debug.LogError("Video failed to show");
        }
    }

    public void RandomItems(){
        characterCustomizationMenu.RandomItems5();

        if(characterCustomizationMenu.outfitsLeft + characterCustomizationMenu.footwearLeft + characterCustomizationMenu.headwearLeft + characterCustomizationMenu.tHeadwearLeft + characterCustomizationMenu.hairLeft + characterCustomizationMenu.facialHairLeft < 5){
            item5Cover.SetActive(true);
        }
    }

    public void RemoveForcedAds(){
        PlayerPrefs.SetInt("PlayAds", 1);

        removeAds.SetActive(true);
        
    }

    public void Back(){
        characterCustomizationMenu.UpdateUnlocking();

        gameObject.SetActive(false);
    }
}
