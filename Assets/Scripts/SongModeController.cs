using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SongModeController : MonoBehaviour
{
    public string mode;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        PlayerPrefs.SetString("Mode",mode);
    }
}
