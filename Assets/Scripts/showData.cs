using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class showData:MonoBehaviour
{
    [SerializeField]
    public Button[] buttons;
    int countforbtn = 0;
    int countforid = 0;
    bool haveData = false;
    int temp;
    public GameObject content;

    private void Update() // Adding text to the buttons according to json data for representing tables and id instead of points which you can see on one click.
    {
        if(haveData == false)
        {
            if (API.gotData)
            {
                for(int i = 0; i< buttons.Length; i++)
                {
                    if(i % 2 == 0)
                    {
                        buttons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(API.clientstoShow[countforbtn].label);
                        
                        countforbtn++;
                    }
                    else if(i % 2 == 1)
                    {
                        buttons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(API.clientstoShow[countforid].id.ToString());
                        countforid++;
                    }
                }
                
                haveData = true;
            }
        } 
    }

    public void clearChild()  // clearing  the buttons as per choice of the filter to present a new list of buttons!
    {
        while (content.transform.childCount > 0)
        {
            int i = 0;
            content.transform.GetChild(i).SetParent(null,false);
            i++;
        }
    }

    public void keepScale(Button btn)  // keeping the local scale of the buttons since it changes when detached from the parent.
    {
        btn.transform.localScale = Vector3.one;
    }

    public void handleInputData(int val)  // functionality for handling the filtering task of dropdown.
    {
        if(val == 0)
        {
            clearChild();
            // do nothing.
        }
        if(val == 1)
        {
            clearChild();
            foreach (Button button in buttons)
            {
                keepScale(button);
                button.transform.SetParent(content.transform, false);
            }
        }
        if(val == 2)
        {
            clearChild();
            foreach (Button button in buttons)
            {
                for(int i=0; i < API.clientstoShow.Count; i++)
                {
                    if(API.clientstoShow[i].label == button.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        temp = i;
                        break;
                    }
                }
                if (API.clientstoShow[temp].isManager)
                {
                    keepScale(button);
                    button.transform.SetParent(content.transform, false);
                }
            }
        }
        if(val == 3)
        {
            clearChild();
            foreach (Button button in buttons)
            {
                for (int i = 0; i < API.clientstoShow.Count; i++)
                {
                    if (API.clientstoShow[i].label == button.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        temp = i;
                        break;
                    }
                }
                if (API.clientstoShow[temp].isManager == false)
                {
                    keepScale(button);
                    button.transform.SetParent(content.transform, false);
                }
            }
        }
    }

}
