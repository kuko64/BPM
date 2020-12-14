using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class controls the button behaviour on button press and collision with a note
public class CNS_StringButton : MonoBehaviour
{

    public Material buttonDownMaterial;
    private Material buttonUpMaterial;

    private KeyCode keyToPress;
    private bool inputEnabled=true;

    // set in Inspector
    public GameObject noteToCreate;
    public GameObject song;
    

    // Start is called before the first frame update
    void Start()
    {
        
        buttonUpMaterial = GetComponent<Renderer>().material;
        string keyCodeString = PlayerPrefs.GetString(this.name);
        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode),keyCodeString);
    }

    // Update is called once per frame
    void Update()
    {
        if(inputEnabled)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                GetComponent<Renderer>().material = buttonDownMaterial;

                // create new notes and set as child of the song prefab
                GameObject newNote = Instantiate(noteToCreate, transform.position, transform.rotation);
                newNote.transform.SetParent(song.transform); 
        
            }
            if (Input.GetKeyUp(keyToPress))
            {
                GetComponent<Renderer>().material = buttonUpMaterial; 
            } 

        }
    }

    public void DisableInput()
    {
        inputEnabled=false;
    }

}
