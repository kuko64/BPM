using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SL_PlayButton : MonoBehaviour
{
    
    private AudioClip song;
    private AudioSource audioSource;

    public Sprite playButtonSprite;
    public Sprite pauseButtonSprite;




    public void InitButton(AudioClip song)
    {
        this.song = song;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song;
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
