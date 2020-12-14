using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_SongButtonControl : MonoBehaviour
{
    public GameObject buttonTemplate;

    // Start is called before the first frame update
    void Start()
    {
        AudioClip[] games = Resources.LoadAll<AudioClip>("Music");

        foreach(var game in games)
        {
            string songName = game.name;
            

            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            button.name=game.name;
            button.SetActive(true);
            GameObject songButton = button.GetComponent<HandleButtons>().songButton;
            GameObject playButton = button.GetComponent<HandleButtons>().playButton;
            songButton.GetComponent<SL_ListButton>().InitButton(game);
            playButton.GetComponent<SL_PlayButton>().InitButton(game);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
