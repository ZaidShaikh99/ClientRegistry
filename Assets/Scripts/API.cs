using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

public class API : MonoBehaviour
{
    [SerializeField]
    private string URL = "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";
    public static List<ClientInfo> clientstoShow { get; set; }
    public static ClientData datatoShow { get; set; }
    public static bool gotData = false;
    private void Awake()
    {
        getData();
    }
    private void getData() => StartCoroutine(getData_Coroutine());

    IEnumerator getData_Coroutine()  // for calling the API to get JSON data and to share it with showdata class for representation task!
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log(request.error);
        }
        else
        {
            Registry registry = new Registry();
            registry = JsonConvert.DeserializeObject<Registry>(request.downloadHandler.text);
            clientstoShow = registry.clients;
            datatoShow = registry.data;
            Debug.Log(clientstoShow[0].label);
            gotData = true;
        }
    }

}
