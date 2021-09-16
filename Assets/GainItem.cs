using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GainItem : MonoBehaviour
{
    public GameObject gainItemButton;
    public GameObject gainItemScreen;

    public GameObject newItemScreen;
    public Image man;
    public Sprite[] manArt;
    public Image item;
    public Text itemName;

    public GameObject outfitButton;
    public GameObject footwearButton;
    public GameObject headwearButton;
    public GameObject hairButton;


    public Sprite[] outfitSprites;
    public Sprite[] footwearSprites;
    public Sprite[] headwearSprites;
    public Sprite[] THWSprites;
    public Sprite[] hairSprites;
    public Sprite[] facialHairSprites;

    public int outfitsLeft;
    public int footwearLeft;
    public int hairLeft;
    public int facialHairLeft;
    public int THeadwearLeft;
    public int headwearLeft;

    void Awake(){
        //Get Arrays
        outfitSprites = new Sprite[Resources.LoadAll<Sprite>("0Outfit").Length/5];
        for(int x = 0; x < Resources.LoadAll<Sprite>("0Outfit").Length/5; x++){
            outfitSprites[x] = Resources.LoadAll<Sprite>("0Outfit")[5 * x];
            if(PlayerPrefs.GetInt("BoughtOutfit" + x) == 0){
                outfitsLeft++;
            }
        }

        footwearSprites = new Sprite[Resources.LoadAll<Sprite>("2Footwear").Length/5+1];
        footwearSprites[0] = Resources.Load<Sprite>("Empty");
        for(int x = 1; x < Resources.LoadAll<Sprite>("2Footwear").Length/5 + 1; x++){
            footwearSprites[x] = Resources.LoadAll<Sprite>("2Footwear")[5 * (x-1)];
            if(PlayerPrefs.GetInt("BoughtFootwear" + x) == 0)
                footwearLeft++;
        }

        headwearSprites = new Sprite[Resources.LoadAll<Sprite>("6Headwear").Length/5+1];
        headwearSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 1; x < Resources.LoadAll<Sprite>("6Headwear").Length/5+1; x++){
            headwearSprites[x] = Resources.LoadAll<Sprite>("6Headwear")[5 * (x-1)];
            if(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 0)
                headwearLeft++;
        }

        THWSprites = new Sprite[Resources.LoadAll<Sprite>("7TransparentHeadwear").Length/5+1];
        THWSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 1; x < Resources.LoadAll<Sprite>("7TransparentHeadwear").Length/5+1; x++){
            THWSprites[x] = Resources.LoadAll<Sprite>("7TransparentHeadwear")[5 * (x-1)];
            if(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 0)
                THeadwearLeft++;
        }

        hairSprites = new Sprite[Resources.LoadAll<Sprite>("5Hair").Length/5+1];
        hairSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 1; x < Resources.LoadAll<Sprite>("5Hair").Length/5+1; x++){
            hairSprites[x] = Resources.LoadAll<Sprite>("5Hair")[5 * (x-1)];
            if(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 0)
                hairLeft++;
        }

        facialHairSprites = new Sprite[Resources.LoadAll<Sprite>("4FacialHair").Length/5+1];
        facialHairSprites[0] = Resources.Load<Sprite>("Empty"); 
        for(int x = 1; x < Resources.LoadAll<Sprite>("4FacialHair").Length/5+1; x++){
            facialHairSprites[x] = Resources.LoadAll<Sprite>("4FacialHair")[5 * (x-1)];
            if(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 0)
                facialHairLeft++;
        }

        if(outfitsLeft == 0)
            outfitButton.SetActive(false);
        if(footwearLeft == 0)
            footwearButton.SetActive(false);
        if(headwearLeft + THeadwearLeft == 0)
            footwearButton.SetActive(false);
        if(hairLeft + facialHairLeft == 0)
            hairButton.SetActive(false);

        if(outfitsLeft + footwearLeft + headwearLeft + THeadwearLeft + hairLeft + facialHairLeft == 0)
            gainItemButton.SetActive(false);
    }

    public void OpenMenu(){
        gainItemButton.SetActive(false);
        gainItemScreen.SetActive(true);   
    }

    public void CatagoryClicked(int id){
        int x = -1;

        newItemScreen.SetActive(true);

        if(id == 0){
            x = Random.Range(0, outfitSprites.Length);
            while(PlayerPrefs.GetInt("BoughtOutfit" + x) == 1){
                x = Random.Range(0, outfitSprites.Length);
            } 

            PlayerPrefs.SetInt("BoughtOutfit" + x, 1);

            man.sprite = manArt[0];
            item.sprite = outfitSprites[x];
            itemName.text = FindObjectOfType<ItemRegistry>().outfitNames[x];
        }
        else if(id == 1){
            x = Random.Range(0, footwearSprites.Length);
            while(PlayerPrefs.GetInt("BoughtFootwear" + x) == 1){
                x = Random.Range(0, footwearSprites.Length);
            }  

            PlayerPrefs.SetInt("BoughtFootwear" + x, 1);

            man.sprite = manArt[0];
            item.sprite = footwearSprites[x]; 
            itemName.text = FindObjectOfType<ItemRegistry>().footwearNames[x];         
        }
        else if(id == 2){
            int y = Random.Range(0,2);
            Debug.Log(y);

            if(headwearLeft > 0 && y == 0){
                x = Random.Range(0, headwearSprites.Length);
                while(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 1){
                    x = Random.Range(0, headwearSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtHeadwear" + x, 1);

                man.sprite = manArt[1];
                item.sprite = headwearSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().headwearNames[x];
                Debug.Log("H: " + x);
            }
            else if(THeadwearLeft > 0 && y == 1){
                x = Random.Range(0, THWSprites.Length);
                while(PlayerPrefs.GetInt("BoughtTHeadwear" + x) == 1){
                    x = Random.Range(0, THWSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtTHeadwear" + x, 1);

                man.sprite = manArt[2];
                item.sprite = THWSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().tHeadwearNames[x];
                Debug.Log("T: " + x);
            }
            else if(headwearLeft > 0){
                x = Random.Range(0, headwearSprites.Length);
                while(PlayerPrefs.GetInt("BoughtHeadwear" + x) == 1){
                    x = Random.Range(0, headwearSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtHeadwear" + x, 1);

                man.sprite = manArt[1];
                item.sprite = headwearSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().headwearNames[x];
                Debug.Log("H: " + x);
            }   
        }
        else if(id == 3){
            int y = Random.Range(0,2);
            Debug.Log(y);

            if(hairLeft > 0 && y == 0){
                x = Random.Range(0, hairSprites.Length);
                while(PlayerPrefs.GetInt("BoughtHair" + x) == 1){
                    x = Random.Range(0, hairSprites.Length);
                } 

                PlayerPrefs.SetInt("BoughtHair" + x, 1); 

                man.sprite = manArt[2];
                item.sprite = hairSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().hairNames[x];
                Debug.Log("H: " + x);
            }
            else if(facialHairLeft > 0 && y == 1){
                x = Random.Range(0, facialHairSprites.Length);
                while(PlayerPrefs.GetInt("BoughtFacialHair" + x) == 1){
                    x = Random.Range(0, facialHairSprites.Length);
                }  

                PlayerPrefs.SetInt("BoughtFacialHair" + x, 1); 

                Debug.Log("F: " + x);
                man.sprite = manArt[0];
                item.sprite = facialHairSprites[x];
                itemName.text = FindObjectOfType<ItemRegistry>().facialHairNames[x];
            }
            else if(hairLeft > 0){
                x = Random.Range(0, hairSprites.Length);
                while(PlayerPrefs.GetInt("BoughtHair" + x) == 1){
                    x = Random.Range(0, hairSprites.Length);
                } 

                PlayerPrefs.SetInt("BoughtHair" + x, 1); 

                man.sprite = manArt[2];
                item.sprite = hairSprites [x]; 
                itemName.text = FindObjectOfType<ItemRegistry>().hairNames[x];
                Debug.Log("H: " + x);
            }   
        }

        gainItemScreen.SetActive(false);
    }

    public void CloseNewItem(){
        newItemScreen.SetActive(false);
    }
}
