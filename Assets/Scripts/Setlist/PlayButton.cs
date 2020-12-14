using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    
    private GameObject song;
    private AudioSource audioSource;

    public Sprite playButtonSprite;
    public Sprite pauseButtonSprite;


    public void InitButton(GameObject song)
    {
        this.song = song;
        audioSource = this.GetComponent<AudioSource>();
        AudioClip songSource = song.GetComponent<AudioSource>().clip;
        audioSource.clip = songSource;
    }

    public void TaskOnClick()
    {
        if(audioSource.isPlaying) 
        {
            audioSource.Pause();
            GetComponent<Image>().sprite = playButtonSprite;
        } else
        {
            audioSource.Play();
            GetComponent<Image>().sprite = pauseButtonSprite;

        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }
}
