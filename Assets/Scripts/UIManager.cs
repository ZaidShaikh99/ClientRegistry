using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject popup;
    public float showtime=  0.3f, hidetime= 0.2f;
    Ease showease = Ease.OutBack;
    Ease hideease = Ease.InBack;


    public void popUp() // for managing the pop UP animation and its data representation as well.
    {
        string clickedbutton = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        if(clickedbutton == "Client1")
        {
            popup.GetComponentInChildren<TextMeshProUGUI>().SetText("Name: "+API.datatoShow._1.name+"\n Points: "+ API.datatoShow._1.points+"\n address: "+ API.datatoShow._1.address);
        }
        else if(clickedbutton == "Client2")
        {
            popup.GetComponentInChildren<TextMeshProUGUI>().SetText("Name: " + API.datatoShow._2.name + "\n Points: " + API.datatoShow._2.points + "\n address: " + API.datatoShow._2.address);
        }
        else if(clickedbutton == "Client3")
        {
            popup.GetComponentInChildren<TextMeshProUGUI>().SetText("Name: " + API.datatoShow._3.name + "\n Points: " + API.datatoShow._3.points + "\n address: " + API.datatoShow._3.address);
        }
        else
        {
            popup.GetComponentInChildren<TextMeshProUGUI>().SetText("NO DATA AVAILABLE FOR THIS CLIENT!");
        }
        popup.transform.DOScale(1,showtime).SetEase(showease);
    }

    public void popOut() // for managing the popout animation!
    {
        popup.transform.DOScale(0, hidetime).SetEase(hideease);
        
    }
 
}
