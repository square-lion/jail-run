using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistry : MonoBehaviour
{
    public string[] outfitNames;

    public string [] footwearNames;

    public string[] facialHairNames;

    public string[] hairNames;

    public string[] headwearNames;

    public string [] tHeadwearNames;


    void Awake(){
        outfitNames = new string[]{
                        "Orange clothes",
                        "White clothes",
                        "Black clothes",
                        "Red clothes",
                        "Yellow clothes",
                        "Lime clothes",
                        "Green clothes",
                        "Cyan clothes",
                        "Light blue clothes",
                        "Blue clothes",
                        "Purple clothes",
                        "Pink clothes",
                        "Guard uniform",
                        "Warden uniform",
                        "Prison clothes",
                        "Farmer's clothes"};

        footwearNames = new string[]{
                        "No shoes",
                        "Black shoes",
                        "Socks",
                        "Brown shoes",
                        "Red shoes",
                        "Orange shoes",
                        "Yellow shoes",
                        "Lime shoes",
                        "Green shoes",
                        "Cyan shoes",
                        "Light blue shoes",
                        "Blue shoes",
                        "Purple shoes",
                        "Pink shoes"};

        facialHairNames = new string[]{
                        "No facial hair",
                        "Light brown mustache",
                        "Black mustache",
                        "Gray mustache",
                        "Red mustache",
                        "Dark brown mustache",
                        "White mustache",
                        "Blonde mustache",
                        "Light brown sideburns",
                        "Black sideburns",
                        "Gray sideburns",
                        "Red sideburns",
                        "Dark brown sideburns",
                        "White sideburns",
                        "Blonde sideburns",
                        "Light brown mutton chops",
                        "Black mutton chops",
                        "Gray mutton chops",
                        "Red mutton chops",
                        "Dark brown mutton chops",
                        "White mutton chops",
                        "Blonde mutton chops",
                        "Light brown beard",
                        "Black beard",
                        "Gray beard",
                        "Red beard",
                        "Dark brown beard",
                        "White beard",
                        "Blonde beard"};

            hairNames = new string[]{
                        "Bald",
                        "Light brown balding hair",
                        "Black balding hair",
                        "Gray balding hair",
                        "Red balding hair",
                        "Dark brown balding hair",
                        "White balding hair",
                        "Blonde balding hair",
                        "Light brown short hair",
                        "Gray short hair",
                        "Black short hair",
                        "Red short hair",
                        "Dark brown short hair",
                        "White short hair",
                        "Blonde short hair",
                        "Light brown long hair",
                        "Black long hair",
                        "Gray long hair",
                        "Red long hair",
                        "Dark brown long hair",
                        "White long hair",
                        "Blonde long hair"};

            headwearNames = new string[]{
                        "No headwear",
                        "Tophat",
                        "Guard's hat",
                        "Warden's hat",
                        "Headphones",
                        "Black beanie",
                        "White beanie",
                        "Red beanie",
                        "Orange beanie",
                        "Yellow beanie",
                        "Lime beanie",
                        "Green beanie",
                        "Cyan beanie",
                        "Light blue beanie",
                        "Blue beanie",
                        "Purple beanie",
                        "Pink beanie",
                        "Prison hat",
                        "Devil horns",
                        "Halo",
                        "Fedora",
                        "Chef's hat",
                        "Black baseball helmet",
                        "White baseball helmet",
                        "Red baseball helmet",
                        "Orange baseball helmet",
                        "Yellow baseball helmet",
                        "Lime baseball halmet",
                        "Green baseball helmet",
                        "Cyan baseball helmet",
                        "Light blue baseball helmet",
                        "Blue baseball helmet",
                        "Purple baseball halmet",
                        "Pink baseball helmet",
                        "Black Football helmet",
                        "White football helmet",
                        "Red football helmet",
                        "Orange football helmet",
                        "Yellow football helmet",
                        "Lime football helmet",
                        "Green football helmet",
                        "Cyan football helmet",
                        "Light blue football helmet",
                        "Blue football helmet",
                        "Purple football helmet",
                        "Pink football helmet",
                        "Black flower",
                        "White flower",
                        "Red flower",
                        "Orange flower",
                        "Yellow flower",
                        "Lime flower",
                        "Green flower",
                        "Cyan flower",
                        "Light blue flower",
                        "Blue flower",
                        "Purple flower",
                        "Pink flower",
                        "Black bow",
                        "White bow",
                        "Red bow",
                        "Orange bow",
                        "Yellow bow",
                        "Lime bow",
                        "Green bow",
                        "Cyan bow",
                        "Light blue bow",
                        "Blue bow",
                        "Purple bow",
                        "Pink bow",
                        "Santa hat",
                        "Birthday hat",
                        "Witch's hat",
                        "Cat ears",
                        "Bunny ears",
                        "Surgical mask",
                        "Fez",
                        "White cap",
                        "Black cap",
                        "Red cap",
                        "Orange cap",
                        "Yellow cap",
                        "Lime cap",
                        "Green cap",
                        "Cyan cap",
                        "Light blue cap",
                        "Blue cap",
                        "Purple cap",
                        "Pink cap",
                        "Ghost mask",
                        "Paper bag"};

            tHeadwearNames = new string[]{
                        "No facewear",
                        "Rosy cheeks",
                        "Glasses",
                        "Rosy cheeks and glasses",
                        "Sunglasses",
                        "Rosy cheeks and sunglasses",
                        "Left monocle",
                        "Rosy cheeks with left monocle",
                        "Right monocle",
                        "Rosy cheeks with right monocle",
                        "Heart glasses"};
        }
    }