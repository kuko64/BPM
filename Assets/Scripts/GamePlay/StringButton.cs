using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class controls the button behaviour on button press and collision with a note
public class StringButton : MonoBehaviour
{

    public Material buttonDownMaterial;
    private Material buttonUpMaterial;
    private bool noteOnButton = false;
    private GameManager gm;
    private GameObject note;
    private KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        buttonUpMaterial = GetComponent<Renderer>().material;
        string keyCodeString = PlayerPrefs.GetString(this.name);
        keyToPress = (KeyCode)System.Enum.Parse(typeof(KeyCode),keyCodeString);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            GetComponent<Renderer>().material = buttonDownMaterial;

            if (noteOnButton) 
            {
                Destroy(note);
                gm.AddStreak();
                gm.AddScore();
                noteOnButton = false;
            }
            else
            {
                gm.ResetStreak();
            }
        }
        
        if (Input.GetKeyUp(keyToPress))
        {
           GetComponent<Renderer>().material = buttonUpMaterial; 
        } 
    }

    void OnTriggerEnter(Collider noteCollider) {
        if(noteCollider.gameObject.tag=="Note"){
            note = noteCollider.gameObject;
            noteOnButton = true;
        }

    }

    void OnTriggerExit(Collider col) {
        noteOnButton = false;
    }

}
