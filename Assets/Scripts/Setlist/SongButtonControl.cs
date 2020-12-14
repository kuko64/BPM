using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class SongButtonControl : MonoBehaviour
{
    public GameObject buttonTemplate;
    public List<GameObject> buttonList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] games = Resources.LoadAll<GameObject>("Games");

        foreach(var game in games)
        {
            string songName = game.name;
            
            // create new Button for a new Game
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            button.name=songName;
            button.SetActive(true);

            //Add Button to a List
            buttonList.Add(button);

            //Init Button
            GameObject songButton = button.GetComponent<HandleButtons>().songButton;
            GameObject playButton = button.GetComponent<HandleButtons>().playButton;
            songButton.GetComponent<ListButton>().InitButton(game);
            playButton.GetComponent<PlayButton>().InitButton(game);

            //Set HighScore 
            Text highScoreText = button.GetComponent<HandleButtons>().highScoreText;
            string highScoreName= "HighScore" + songName;
            highScoreText.text = PlayerPrefs.GetInt(highScoreName).ToString();
            
        }

    }

    public void ShowDeleteButton(){
        foreach(var button in buttonList)
        {
            button.GetComponent<HandleButtons>().DeleteButton();}            
    }

    public void HideDeleteButton(){
        foreach(var button in buttonList)
        {
            button.GetComponent<HandleButtons>().HideButton();}            
    }

    // Remove a button from the Setlist
    public void DeleteButtonFromList(GameObject button)
    {
        buttonList.Remove(button);
        UnityEditor.AssetDatabase.DeleteAsset("Assets/Resources/Games/"+ button.name +".prefab");
        Destroy(button);
    }
}
