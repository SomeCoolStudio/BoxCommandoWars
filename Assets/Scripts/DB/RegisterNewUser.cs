using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class RegisterNewUser : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private GameObject passwordErrorCanvas;
    [SerializeField]
    private GameObject infoErrorCanvas;
    [SerializeField]
    private GameObject connectionErrorCanvas;
    [SerializeField]
    private GameObject registerSuccessCanvas;
    [SerializeField]
    private TMP_InputField username;
    [SerializeField]
    private TMP_InputField email;
    [SerializeField]
    private TMP_InputField password;
    [SerializeField]
    private TMP_InputField confirmPassword;

    [Header("Events")]
    [SerializeField]
    private UnityEvent RegisterSuccessEvent;
    [SerializeField]
    private UnityEvent RegisterFailedEvent;


    [Serializable]
    public class Gamer
    {
        public string username;
        public string email;
        public string password;
    }

    public void Register()
    {
        string username = this.username.text;
        string email = this.email.text;
        string password = this.password.text;

        if (this.password.text != this.confirmPassword.text) 
        {
            Debug.Log("password mismatch");
            RegisterFailedEvent.Invoke();
            passwordErrorCanvas.SetActive(true);
            return;
        }
        else if (this.password.text == "" || this.username.text == "")
        {
            Debug.Log("missing required info");
            RegisterFailedEvent.Invoke();
            infoErrorCanvas.SetActive(true);
            return;
        }

        Gamer gamer = new Gamer();
        gamer.username = username;
        gamer.email = email;
        gamer.password = password;

        string json = JsonUtility.ToJson(gamer);
        StartCoroutine(PostRequest("https://box-commando-flask-deploy.onrender.com/register", json));
    }

    public void ClearRegisterFields()
    {
        this.username.text = "";
        this.email.text = "";
        this.password.text = "";
        this.confirmPassword.text = "";
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

            RegisterFailedEvent.Invoke();
            connectionErrorCanvas.SetActive(true);
            Debug.Log("Error While Sending: " + uwr.error);
        }
      
        else
        {
            registerSuccessCanvas.SetActive(true);
            RegisterSuccessEvent.Invoke();
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
