using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SL_ListButton : MonoBehaviour
{
    public Text buttonText;
    
    private Object game;

    public void InitButton(Object game)
    {
        buttonText.text = game.name;
        this.game = game;
    }

    public void TaskOnClick()
    {
        PlayerPrefs.SetString("Music",game.name);
        SceneManager.LoadScene(5);
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
