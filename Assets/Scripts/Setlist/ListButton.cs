using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListButton : MonoBehaviour
{
    public Text buttonText;
    
    private Object game;

    public void InitButton(Object game)
    {
        buttonText.text = game.name;
        this.game = game;
    }

    //Load next Scene when clicked
    public void TaskOnClick()
    {
        PlayerPrefs.SetString("Song",game.name);
        SceneManager.LoadScene(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
}
