using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNS_ButtonController : MonoBehaviour
{
    public GameObject[] buttons;

    public void SetInputMode()
    {
        foreach(var button in buttons)
           {
               button.GetComponent<CNS_StringButton>().DisableInput();
           }
    }

}

  
