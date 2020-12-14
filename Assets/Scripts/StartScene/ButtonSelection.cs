using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour
{
    bool isSelected;
    public string buttonName;
    public GameObject buttonText;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
        buttonText.GetComponent<Text>().text = PlayerPrefs.GetString(buttonName) +"";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected)
        {
            //check which key is pressed and update in PlayerPrefs
            foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
                if(Input.GetKey(vKey))
                {
                    PlayerPrefs.SetString(buttonName,vKey.ToString());
                    buttonText.GetComponent<Text>().text = vKey.ToString();
                    isSelected=false;
                }
            }
            
        }
    }

    void TaskOnClick()
    {
        isSelected= true;
        buttonText.GetComponent<Text>().text ="";
    }
}
