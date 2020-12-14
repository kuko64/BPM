using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CNS_GameManager : MonoBehaviour
{
    private SongController songController;

    public GameObject songPrefab;


    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        string music = PlayerPrefs.GetString("Music");
        AudioClip loadedSong = Resources.Load("Music/" + music) as AudioClip;

        AudioSource audioSource = songPrefab.GetComponent<AudioSource>();
        audioSource.clip = loadedSong;
        
        //start game
        songController = songPrefab.GetComponent<SongController>();
        songController.Play();
    }

    public void Pause()
    {
        songController.Pause();

    }

    public void Play()
    {
        songController.Play();
    }

}
