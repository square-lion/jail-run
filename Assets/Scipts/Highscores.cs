using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Highscores : MonoBehaviour {
   
    const string privateCode = "zSZ3493E6U-_WLPoWomEqgFLlMXMZe3k-_F3JDjPjWsg";
    const string publicCode = "5d30875076827f17586b6677";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    DisplayHighscores display;

    void Awake(){
        display = GetComponent<DisplayHighscores>();

        //DownloadHighscores();
    }

    public void AddNewHighscore(string username, float time){
        StartCoroutine(UploadNewHighscore(username, time));
    }

    IEnumerator UploadNewHighscore(string username, float time){
        UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + (int)(600000 - time*1000));
        www.SendWebRequest(); 
        yield return www;

        if(string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
            print("Error Uploading" + www.error);
   }

   public void DownloadHighscores(){
       StartCoroutine("DownloadHighscoresFromDatabase");
   }

   IEnumerator DownloadHighscoresFromDatabase(){
        UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        yield return www.SendWebRequest();

        if(string.IsNullOrEmpty(www.error)){
            FormatHighscores(www.downloadHandler.text);
            display.OnHighscoresDownloaded(highscoresList);
        }
        else{
            print("Error Downloading" + www.error);
            display.OnHighscoresFailed();
        }
   }

   void FormatHighscores(string textStream){
       string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
       highscoresList = new Highscore[entries.Length];

       for(int i = 0; i < entries.Length; i ++){
           string[] entryInfo = entries[i].Split(new char[] {'|'});
           string username = entryInfo[0];
           float time = int.Parse(entryInfo[1]);
           highscoresList[i] = new Highscore(username, (600000 - time)/1000);
           //print(highscoresList[i].username + ": " + highscoresList[i].time);
       }
   }
}

public struct Highscore { 
    public string username;
    public float time;

    public Highscore(string _username, float _time){
        username = _username;
        time = _time;
    }
}
