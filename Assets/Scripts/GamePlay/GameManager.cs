using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject song;
    private SongController songController;

    // PlayerPrefs
    private int multiplier=1;
    private int streak=0;

    // Start is called before the first frame update
    void Start()
    {
        // Init PlayerPrefs
        PlayerPrefs.SetInt("Score",0);
        PlayerPrefs.SetInt("Streak",0);
        PlayerPrefs.SetInt("Mult",1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        // load Prefab 
        string currentSong = PlayerPrefs.GetString("Song");
        GameObject loadedSong = Resources.Load("Games/" + currentSong) as GameObject;
        this.song = Instantiate(loadedSong) as GameObject;
    
        //start game
        songController = song.GetComponent<SongController>();
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

    public void AddStreak(){
        streak++;
        if(streak>=40) multiplier= 4;
        else if(streak>=30) multiplier = 3;
        else if(streak>=20) multiplier = 2;
        else multiplier =1;
        PlayerPrefs.SetInt("Streak",streak);
        PlayerPrefs.SetInt("Mult",multiplier);
    }

    public void ResetStreak(){
        streak=0;
        multiplier=1;
        PlayerPrefs.SetInt("Streak",streak);
        PlayerPrefs.SetInt("Mult",multiplier);
    }

    public void AddScore(){
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+ 100*multiplier);
    }


    public void End()
    {
        //save HighScore and load next Scene
        string songName = PlayerPrefs.GetString("Song");
        string highScoreName= "HighScore"+songName;
        if(PlayerPrefs.GetInt(highScoreName)<PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt(highScoreName,PlayerPrefs.GetInt("Score"));
        }
        SceneManager.LoadScene(3);
    }

    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Note"){
             ResetStreak();
        }
        if (col.gameObject.tag == "TheEnd")
        {
            End();
        }
       
    }
}
