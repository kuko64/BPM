using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SongController : MonoBehaviour
{

    public int bpm;
    public bool running;
    private AudioSource audioSource;
    public GameObject endBox;
    public string songName;
    public GameObject inputField;
   // public GameObject textDisplay;

    private string stringToEdit;
    void Awake() 
    {
        this.audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {  
        if (running)
        {
            transform.position -= new Vector3(0,0,bpm / 60f * Time.deltaTime);
        }
    }

    public void Play()
    {
        this.running = true;
        audioSource.Play();
    }

    public void Pause()
    {
        this.running = false;
        audioSource.Pause();
    }

    public void SetTransform()
    {
        Transform songTransform = this.transform;
        GameObject sB = Instantiate(endBox, new Vector3(0f, 0f, -transform.position.z), transform.rotation);
        sB.transform.SetParent(songTransform,false);
        transform.position = new Vector3(1.5f, 0f, 0f);
        Pause();

    }

    public void SavePrefab()
    {
        songName = inputField.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>().text = "Saved successfully";
        UnityEditor.PrefabUtility.SaveAsPrefabAsset((GameObject)gameObject, "Assets/Resources/Games/"+ songName+".prefab");

    }

}
