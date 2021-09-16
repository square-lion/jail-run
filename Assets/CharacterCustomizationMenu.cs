using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;

public class CharacterCustomizationMenu : MonoBehaviour
{
    [Header("Display")]
    public Image skinDisplay;
    public Image eyesDisplay;
    public Image hairDisplay;
    public Image headwearDisplay;
    public Image outfitDisplay;
    public Image footwearDisplay;
    public Image facialHairDisplay;
    public Image transparentHeadwearDisplay;
    
    [Space(5)]
    [Header("Outfit")]
    public int curOutfitID;
    public Sprite[] outfitSprites;
    public Transform outfitDisplays;
    public int outfitsLeft; 
    
    [Space(5)]
    [Header("Skin")]
    public int curSkinID;
    public Sprite[] skinSprites;

    [Space(5)]
    [Header("Footwear")]
    public int curFootwearID;
    public Sprite[] footwearSprites;
    public Transform footwearDisplays;
    public int footwearLeft;

    [Space(5)]
    [Header("Eyes")]
    public int curEyesID;
    public Sprite[] eyeSprites;

    [Space(5)]
    [Header("Facial Hair")]
    public int curFacialHairID;
    public Sprite[] facialHairSprites;
    public Transform facialhairDisplays;
    public int facialHairLeft;

    [Space(5)]
    [Header("Hair")]
    public int curHairID;
    public Sprite[] hairSprites;  
    public Transform hairDisplays;
    public int hairLeft;

    [Space(5)]
    [Header("Headwear")]
    public int curHeadwearID;
    public Sprite[] headwearSprites;
    public Transform headwearDisplays;
    public int headwearLeft;

    [Space(5)]
    [Header("Transparent Headwear")]
    public int curTHWID;
    public Sprite[] THWSprites;
    public Transform THWDisplays;
    public int tHeadwearLeft;
    
    
    public GameObject[] menus;

    [Space(5)]
    [Header("New Item Screen")]
    public GameObject newItemScreen;
    public Image man;
    public Sprite[] manArt;
    public Image item;
    public Text itemName;

    [Space(5)]
    [Header("5 Item Screen")]
    public GameObject item5Screen;
    public Image[] mans;
    public Image[] items;
    public Text[] itemNames;

    void Awake(){
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
        headwearSprites = new Sprite[Resources.LoadAll<Sprite>("6Headwear").Length/5+1];
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


        //Change Display
        ChangeSkinColor(curSkinID);
        ChangeEyeColor(curEyesID);
        ChangeHair(curHairID);
        ChangeHeadwear(curHeadwearID);
        ChangeOutfit(curOutfitID);
        ChangeFootwear(curFootwearID);
        ChangeFacialHair(curFacialHairID);
        ChnageTHW(curTHWID);  

        UpdateUnlocking(); 

        CheckHowManyLeft();   
    }

    public void UpdateUnlocking(){
        CheckHowManyLeft();

        for(int x = 1; x < outfitDisplays.childCount; x++){
            if(PlayerPrefs.GetInt("BoughtOutfit" + x) == 0)
                foreach(Image s in outfitDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.black;
            else  
                foreach(Image s in outfitDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.white;     
        }

        for(int x = 2; x < footwearDisplays.childCount; x++){
            if(PlayerPrefs.GetInt("BoughtFootwear" + x) == 0)
                foreach(Image s in footwearDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.black;  
            else
                foreach(Image s in footwearDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.white;     
        }

        for(int x = 1; x < facialhairDisplays.childCount; x++){
            if(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 0)
                foreach(Image s in facialhairDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.black; 
            else
                foreach(Image s in facialhairDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.white;      
        }

        for(int x = 1; x < hairDisplays.childCount; x++){
            if(PlayerPrefs.GetInt("BoughtHair" + x) == 0)
                foreach(Image s in hairDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.black;
            else
                foreach(Image s in hairDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.white;       
        }

        for(int x = 1; x < headwearDisplays.childCount; x++){
            if(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 0)
                foreach(Image s in headwearDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.black;
            else
                foreach(Image s in headwearDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.white;    
        }

        for(int x = 1; x < THWDisplays.childCount; x++){
            if(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 0)
                foreach(Image s in THWDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.black; 
            else
                 foreach(Image s in THWDisplays.GetChild(x).GetComponentsInChildren<Image>())
                    s.color = Color.white;      
        }
    }
    
    
    //When Catagory Is Clicked
    public void OpenMenu(int id){
        foreach(GameObject m in menus)
            m.SetActive(false);

        menus[id].SetActive(true);
    }

    //When A Skin Color Is Clicked
    public void ChangeSkinColor(int id){
        curSkinID = id;
        PlayerPrefs.SetInt("Skin", id);
        skinDisplay.sprite = skinSprites[curSkinID];
    }
    //When An Eye Color Is Clicked
    public void ChangeEyeColor(int id){
        curEyesID = id;
        PlayerPrefs.SetInt("Eyes", id);
        eyesDisplay.sprite = eyeSprites[curEyesID];
    }
    //When  Hair Is Clicked
    public void ChangeHair(int id){
        if(PlayerPrefs.GetInt("BoughtHair" + id) == 1){
            curHairID = id;
            PlayerPrefs.SetInt("Hair", id);
            hairDisplay.sprite = hairSprites[curHairID];
        }
    }
    //When Headwear Is Clicked
    public void ChangeHeadwear(int id){
        if(PlayerPrefs.GetInt("BoughtHeadwear" + id) == 1){
            curHeadwearID = id;
            PlayerPrefs.SetInt("Headwear", id);
            headwearDisplay.sprite = headwearSprites[curHeadwearID];
        }
    }
    //When An Outfit Is Clicked
    public void ChangeOutfit(int id){
        if(PlayerPrefs.GetInt("BoughtOutfit" + id) == 1){
            curOutfitID = id;
            PlayerPrefs.SetInt("Outfit", id);
            outfitDisplay.sprite = outfitSprites[curOutfitID];
        }
    }
    //When Footwear Is Clicked
    public void ChangeFootwear(int id){
        if(PlayerPrefs.GetInt("BoughtFootwear" + id) == 1){
            curFootwearID = id;
            PlayerPrefs.SetInt("Footwear", id);
            footwearDisplay.sprite = footwearSprites[curFootwearID];
        }
    }
    //When Facial Hair Is Clicked
    public void ChangeFacialHair(int id){
        if(PlayerPrefs.GetInt("BoughtFacialHair" + id) == 1){
            curFacialHairID = id;
            PlayerPrefs.SetInt("FacialHair", id);
            facialHairDisplay.sprite = facialHairSprites[curFacialHairID];
        }
    }  
    //When Transparent Headwear Is Clicked
    public void ChnageTHW(int id){
        if(PlayerPrefs.GetInt("BoughtTHeadwear" + id) == 1){
            curTHWID = id;
            PlayerPrefs.SetInt("THeadwear", id);
            transparentHeadwearDisplay.sprite = THWSprites[curTHWID];
        }
    }

    public void Close(){
       FindObjectOfType<MainMenu>().UpdatePreview();
        gameObject.SetActive(false);
 
    }

    public void Randomize(){
        int x = 0;

        //Skin
        ChangeSkinColor(Random.Range(0, skinSprites.Length));

        //Eyes
        ChangeEyeColor(Random.Range(0, eyeSprites.Length));

        //Hair
        x = Random.Range(0, hairSprites.Length);
        while(PlayerPrefs.GetInt("BoughtHair" + x) == 0){
            x = Random.Range(0, hairSprites.Length);
        } 
        ChangeHair(x);

        //Headwear
        x = Random.Range(0, headwearSprites.Length);
        while(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 0){
            x = Random.Range(0, headwearSprites.Length);
        } 
        ChangeHeadwear(x);        

        //Outifts
        x = Random.Range(0, outfitSprites.Length);
        while(PlayerPrefs.GetInt("BoughtOutfit" + x) == 0){
            x = Random.Range(0, outfitSprites.Length);
        } 
        ChangeOutfit(x);

        //Footwear
        x = Random.Range(0, footwearSprites.Length);
        while(PlayerPrefs.GetInt("BoughtFootwear" + x) == 0){
            x = Random.Range(0, footwearSprites.Length);
        } 
        ChangeFootwear(x);

        //Facial Hair
        x = Random.Range(0, facialHairSprites.Length);
        while(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 0){
            x = Random.Range(0, facialHairSprites.Length);
        } 
        ChangeFacialHair(x);

        //T Headwear 
        x = Random.Range(0, THWSprites.Length);
        while(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 0){
            x = Random.Range(0, THWSprites.Length);
        } 
        ChnageTHW(x);
    }

    public void CheckHowManyLeft(){
        outfitsLeft = 0;
        footwearLeft = 0;
        facialHairLeft = 0;
        hairLeft = 0;
        headwearLeft = 0;
        tHeadwearLeft = 0;

        for(int x = 1; x < outfitSprites.Length; x++){
            if(PlayerPrefs.GetInt("BoughtOutfit" + x) == 0)
                outfitsLeft++;
        }

        for(int x = 2; x < footwearSprites.Length; x++){
            if(PlayerPrefs.GetInt("BoughtFootwear" + x) == 0)
                footwearLeft++;
        }

        for(int x = 1; x < facialHairSprites.Length; x++){
            if(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 0)
                facialHairLeft++;
        }

        for(int x = 1; x < hairSprites.Length; x++){
            if(PlayerPrefs.GetInt("BoughtHair" + x) == 0)
                hairLeft++;
        }

        for(int x = 1; x < headwearSprites.Length; x++){
            if(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 0)
                headwearLeft++;
        }

        for(int x = 1; x < THWSprites.Length; x++){
            if(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 0)
                tHeadwearLeft++;
        }

    }

    public void OneRandomItem(){

        int x = 0;
        newItemScreen.SetActive(true);

        while(true){
            int catagory = Random.Range(0, 6);

            //Give Outfit
            if(catagory == 0 && outfitsLeft != 0){
                x = Random.Range(0, outfitSprites.Length);

                while(PlayerPrefs.GetInt("BoughtOutfit" + x) == 1){
                    x = Random.Range(0, outfitSprites.Length);
                } 

                PlayerPrefs.SetInt("BoughtOutfit" + x, 1);

                man.sprite = manArt[0];
                item.sprite = outfitSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().outfitNames[x];
                break;
            }

            //Give Footwear
            else if(catagory == 1 && footwearLeft != 0){
                x = Random.Range(0, footwearSprites.Length);

                while(PlayerPrefs.GetInt("BoughtFootwear" + x) == 1){
                    x = Random.Range(0, footwearSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtFootwear" + x, 1);

                man.sprite = manArt[0];
                item.sprite = footwearSprites[x]; 
                itemName.text = FindObjectOfType<ItemRegistry>().footwearNames[x];
                break;
            }

            //Give Headwear
            else if(catagory == 2 && headwearLeft != 0){
                x = Random.Range(0, headwearSprites.Length);

                while(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 1){
                    x = Random.Range(0, headwearSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtHeadwear" + x, 1);

                man.sprite = manArt[1];
                item.sprite = headwearSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().headwearNames[x];
                break;
            }

            //Give T Headwear
            else if(catagory == 3 && tHeadwearLeft != 0){
                x = Random.Range(0, THWSprites.Length);

                while(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 1){
                    x = Random.Range(0, THWSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtTHeadwear" + x, 1);

                man.sprite = manArt[2];
                item.sprite = THWSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().tHeadwearNames[x];
                break;
            }

            //Give Hair
            else if(catagory == 4 && hairLeft != 0){
                x = Random.Range(0, hairSprites.Length);

                while(PlayerPrefs.GetInt("BoughtHair" + x) == 1){
                    x = Random.Range(0, hairSprites.Length);
                } 

                PlayerPrefs.SetInt("BoughtHair" + x, 1); 

                man.sprite = manArt[2];
                item.sprite = hairSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().hairNames[x];
                break;
            }

            //Give Facial Hair
            else if(catagory == 1 && facialHairLeft != 0){
                x = Random.Range(0, facialHairSprites.Length);

                while(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 1){
                    x = Random.Range(0, facialHairSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtFacialHair" + x, 1); 

                Debug.Log("F: " + x);
                man.sprite = manArt[0];
                item.sprite = facialHairSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().facialHairNames[x];
                break;
            }
        }

        UpdateUnlocking();
    }

    public void CloseNewItem(){
        newItemScreen.SetActive(false);
        item5Screen.SetActive(false);
    }

    public void RandomItems5(){
        CheckHowManyLeft();
        item5Screen.SetActive(true);
        int x = 0;

        bool got = false;

        for(int a = 0; a < 5; a++){
            got = false;
            while(!got){
                int catagory = Random.Range(0, 6);

                //Give Outfit
                if(catagory == 0 && outfitsLeft != 0){
                    x = Random.Range(0, outfitSprites.Length);

                    while(PlayerPrefs.GetInt("BoughtOutfit" + x) == 1){
                        x = Random.Range(0, outfitSprites.Length);
                    } 

                    PlayerPrefs.SetInt("BoughtOutfit" + x, 1);

                    mans[a].sprite = manArt[0];
                    items[a].sprite = outfitSprites[x];
                    itemNames[a].text = FindObjectOfType<ItemRegistry>().outfitNames[x];
                    got = true;
                }

                //Give Footwear
                else if(catagory == 1 && footwearLeft != 0){
                    x = Random.Range(0, footwearSprites.Length);

                    while(PlayerPrefs.GetInt("BoughtFootwear" + x) == 1){
                        x = Random.Range(0, footwearSprites.Length);
                    }  

                    PlayerPrefs.SetInt("BoughtFootwear" + x, 1);

                    mans[a].sprite = manArt[0];
                    items[a].sprite = footwearSprites[x]; 
                    itemNames[a].text = FindObjectOfType<ItemRegistry>().footwearNames[x];
                    got = true;
                }

                //Give Headwear
                else if(catagory == 2 && headwearLeft != 0){
                    x = Random.Range(0, headwearSprites.Length);

                    while(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 1){
                        x = Random.Range(0, headwearSprites.Length);
                    }  

                    PlayerPrefs.SetInt("BoughtHeadwear" + x, 1);

                    mans[a].sprite = manArt[1];
                    items[a].sprite = headwearSprites[x];
                    itemNames[a].text = FindObjectOfType<ItemRegistry>().headwearNames[x];
                    got = true;
                }

                //Give T Headwear
                else if(catagory == 3 && tHeadwearLeft != 0){
                    x = Random.Range(0, THWSprites.Length);

                    while(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 1){
                        x = Random.Range(0, THWSprites.Length);
                    }  

                    PlayerPrefs.SetInt("BoughtTHeadwear" + x, 1);

                    mans[a].sprite = manArt[2];
                    items[a].sprite = THWSprites[x];
                    itemNames[a].text = FindObjectOfType<ItemRegistry>().tHeadwearNames[x];
                    got = true;
                }

                //Give Hair
                else if(catagory == 4 && hairLeft != 0){
                    x = Random.Range(0, hairSprites.Length);

                    while(PlayerPrefs.GetInt("BoughtHair" + x) == 1){
                        x = Random.Range(0, hairSprites.Length);
                    } 

                    PlayerPrefs.SetInt("BoughtHair" + x, 1); 

                    mans[a].sprite = manArt[2];
                    items[a].sprite = hairSprites[x];
                    itemNames[a].text = FindObjectOfType<ItemRegistry>().hairNames[x];
                    got = true;
                }

                //Give Facial Hair
                else if(catagory == 1 && facialHairLeft != 0){
                    x = Random.Range(0, facialHairSprites.Length);

                    while(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 1){
                        x = Random.Range(0, facialHairSprites.Length);
                    }  

                    PlayerPrefs.SetInt("BoughtFacialHair" + x, 1); 

                    Debug.Log("F: " + x);
                    mans[a].sprite = manArt[0];
                    items[a].sprite = facialHairSprites[x];
                    itemNames[a].text = FindObjectOfType<ItemRegistry>().facialHairNames[x];
                    got = true;
                }
            }
        }

        UpdateUnlocking();
    }
}