using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleButtons : MonoBehaviour
{
    public GameObject songButton;
    public GameObject playButton;
    public GameObject deleteButton;
    public Text highScoreText;

    public void DeleteButton()
    {
        deleteButton.SetActive(true);
    }

    public void HideButton()
    {
         deleteButton.SetActive(false);
    }
}
