using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class LoginUser : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private GameObject inputErrorCanvas;
    [SerializeField]
    private GameObject connectionErrorCanvas;
    [SerializeField]
    private TMP_InputField username;
    [SerializeField]
    private TMP_InputField password;

    [Header("Events")]
    [SerializeField]
    private UnityEvent LoginSuccessEvent;
    [SerializeField]
    private UnityEvent LoginFailedEvent;



    [Serializable]
    public class Gamer
    {
        public string username;
        public string password;
    }

    public void Login()
    {
        string username = this.username.text;
        string password = this.password.text;

        Gamer gamer = new Gamer();

        gamer.username = username;
        gamer.password = password;

        string json = JsonUtility.ToJson(gamer);
        StartCoroutine(PostRequest("https://box-commando-flask-deploy.onrender.com/login", json));
    }

    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            LoginFailedEvent.Invoke();
            connectionErrorCanvas.SetActive(true);
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else if (uwr.result == UnityWebRequest.Result.ProtocolError) 
        {
            LoginFailedEvent.Invoke();
            inputErrorCanvas.SetActive(true);
            Debug.Log("Error While Sending: " + uwr.error); 
        }
        else
        {
            LoginSuccessEvent.Invoke();
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
