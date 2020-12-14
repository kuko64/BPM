using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitControls : MonoBehaviour
{

    Dictionary<string,string> dict = new Dictionary<string,string>(){
        {"Button1","C"},
        {"Button2","V"},
        {"Button3","B"},
        {"Button4","N"}
    };
    // Start is called before the first frame update
    void Start()
    {
        foreach(KeyValuePair<string,string>kvp in dict)
        {
            // if no key was assigned yet, assign default keys
            if(string.IsNullOrEmpty(PlayerPrefs.GetString(kvp.Key)))
            {
                PlayerPrefs.SetString(kvp.Key,kvp.Value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
