using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPP : MonoBehaviour
{
    public string namePP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        string songName = PlayerPrefs.GetString("Song");
        if(namePP=="HighScore")
        {
            string highScoreName = "HighScore"+songName;
            GetComponent<Text>().text = PlayerPrefs.GetInt(highScoreName) +""; 
        }
        else{
            GetComponent<Text>().text = PlayerPrefs.GetInt(namePP) +""; 
        }
        

     
    }
}
