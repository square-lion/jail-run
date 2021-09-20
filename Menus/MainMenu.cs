using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;

	public GameObject levelSelectMenu;
	public GameObject characterMenu;
    public GameObject shopMenu;
    public GameObject settingsMenu;
    public GameObject leaderboardMenu;

	public Text personalBest;

	public Image[] previews;

	    [Space(5)]
    [Header("Outfit")]
    public int curOutfitID;
    public Sprite[] outfitSprites;  
    
    [Space(5)]
    [Header("Skin")]
    public int curSkinID;
    public Sprite[] skinSprites;

    [Space(5)]
    [Header("Footwear")]
    public int curFootwearID;
    public Sprite[] footwearSprites;

    [Space(5)]
    [Header("Eyes")]
    public int curEyesID;
    public Sprite[] eyeSprites;

    [Space(5)]
    [Header("Facial Hair")]
    public int curFacialHairID;
    public Sprite[] facialHairSprites;

    [Space(5)]
    [Header("Hair")]
    public int curHairID;
    public Sprite[] hairSprites;  

    [Space(5)]
    [Header("Headwear")]
    public int curHeadwearID;
    public Sprite[] headwearSprites;

    [Space(5)]
    [Header("Transparent Headwear")]
    public int curTHWID;
    public Sprite[] THWSprites;

	    void Awake(){
        //First Time
        if(PlayerPrefs.GetInt("FirstTime") == 0){
            PlayerPrefs.SetInt("BoughtHair0", 1);
            PlayerPrefs.SetInt("BoughtHeadwear0", 1);
            PlayerPrefs.SetInt("BoughtOutfit0", 1);
            PlayerPrefs.SetInt("BoughtFootwear0", 1);
            PlayerPrefs.SetInt("BoughtFootwear1", 1);
            PlayerPrefs.SetInt("BoughtFacialHair0", 1);
            PlayerPrefs.SetInt("BoughtTHeadwear0", 1);
            PlayerPrefs.SetInt("Footwear", 1);
            PlayerPrefs.SetInt("FirstTime", 1);
            Debug.Log("Done");
        }




        //Set Arrays

        //Outfit
        outfitSprites = new Sprite[Resources.LoadAll<Sprite>("0Outfit").Length/5];
        for(int x = 0; x < Resources.LoadAll<Sprite>("0Outfit").Length/5; x++){
            outfitSprites[x] = Resources.LoadAll<Sprite>("0Outfit")[5 * x];
        }

        //Skin
        skinSprites = new Sprite[Resources.LoadAll<Sprite>("1Skin").Length/5];
        for(int x = 0; x < Resources.LoadAll<Sprite>("1Skin").Length/5; x++){
            skinSprites[x] = Resources.LoadAll<Sprite>("1Skin")[5 * x];
        }

        //Footwear
        footwearSprites = new Sprite[Resources.LoadAll<Sprite>("2Footwear").Length/5+1];
        footwearSprites[0] = Resources.Load<Sprite>("Empty");
        for(int x = 0; x < Resources.LoadAll<Sprite>("2Footwear").Length/5; x++){
            footwearSprites[x+1] = Resources.LoadAll<Sprite>("2Footwear")[5 * x];
        }

        //Eyes
        eyeSprites = new Sprite[Resources.LoadAll<Sprite>("3Eyes").Length/5];
        for(int x = 0; x < Resources.LoadAll<Sprite>("3Eyes").Length/5; x++){
            eyeSprites[x] = Resources.LoadAll<Sprite>("3Eyes")[5 * x];
        }

        //Facial Hair
        facialHairSprites = new Sprite[Resources.LoadAll<Sprite>("4FacialHair").Length/5+1];
        facialHairSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 0; x < Resources.LoadAll<Sprite>("4FacialHair").Length/5; x++){
            facialHairSprites[x+1] = Resources.LoadAll<Sprite>("4FacialHair")[5 * x];
        }

        //Hair
        hairSprites = new Sprite[Resources.LoadAll<Sprite>("5Hair").Length/5+1];
        hairSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 0; x < Resources.LoadAll<Sprite>("5Hair").Length/5; x++){
            hairSprites[x+1] = Resources.LoadAll<Sprite>("5Hair")[5 * x];
        }

        //Headwear
        headwearSprites = new Sprite[Resources.LoadAll<Sprite>("6Headwear").Length/5+2];
        headwearSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 0; x < Resources.LoadAll<Sprite>("6Headwear").Length/5; x++){
            headwearSprites[x+1] = Resources.LoadAll<Sprite>("6Headwear")[5 * x];
        }

        //Transparent Headwear
        THWSprites = new Sprite[Resources.LoadAll<Sprite>("7TransparentHeadwear").Length/5+1];
        THWSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 0; x < Resources.LoadAll<Sprite>("7TransparentHeadwear").Length/5; x++){
            THWSprites[x+1] = Resources.LoadAll<Sprite>("7TransparentHeadwear")[5 * x];
        }

        //Set IDs
        curSkinID = PlayerPrefs.GetInt("Skin");
        curEyesID = PlayerPrefs.GetInt("Eyes");
        curHairID = PlayerPrefs.GetInt("Hair");
        curHeadwearID = PlayerPrefs.GetInt("Headwear");
        curOutfitID = PlayerPrefs.GetInt("Outfit");
        curFootwearID = PlayerPrefs.GetInt("Footwear");
        curFacialHairID = PlayerPrefs.GetInt("FacialHair");
        curTHWID = PlayerPrefs.GetInt("THeadwear");
    }

	void Start(){
		personalBest.text = "PB: " + String.Format("{0:#,##0.000;(#,##0.000);Zero}", PlayerPrefs.GetFloat("BestTime")) + " seconds";

		if(PlayerPrefs.GetInt("FromLS") == 1)
			levelSelectMenu.SetActive(true);
		else
			levelSelectMenu.SetActive(false);

		UpdatePreview();
	}

	public void UpdatePreview(){
		previews[0].sprite = outfitSprites[PlayerPrefs.GetInt("Outfit")];
		previews[1].sprite = skinSprites[PlayerPrefs.GetInt("Skin")];
		previews[2].sprite = footwearSprites[PlayerPrefs.GetInt("Footwear")];
		previews[3].sprite = eyeSprites[PlayerPrefs.GetInt("Eyes")];
		previews[4].sprite = facialHairSprites[PlayerPrefs.GetInt("FacialHair")];
		previews[5].sprite = hairSprites[PlayerPrefs.GetInt("Hair")];
		previews[6].sprite = headwearSprites[PlayerPrefs.GetInt("Headwear")];
		previews[7].sprite = THWSprites[PlayerPrefs.GetInt("THeadwear")];
	}


	public void NewGame()
	{
		PlayerPrefs.SetInt("FromLS", 0);
		SceneManager.LoadScene(startLevel);
		FindObjectOfType<Timer>().StartTimer();
	}
	public void LevelSelect()
	{
		levelSelectMenu.SetActive(true);
		UpdatePreview();
	}

    public void Shop(){
        shopMenu.SetActive(true);
    }

	public void CharacterCostumizer(){
		characterMenu.SetActive(true);
		UpdatePreview();
	}

    public void Settings(){
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void Leaderboard(){
        leaderboardMenu.SetActive(!leaderboardMenu.activeSelf);
    }

	public void Exit()
	{
		Application.Quit ();	
	}

}
