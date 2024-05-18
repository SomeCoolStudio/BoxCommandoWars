using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SaveScore : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private GameObject missingUsernameErrorCanvas;
    [SerializeField]
    private GameObject connectionErrorCanvas;
    [SerializeField]
    private GameObject scoreTooLowErrorCanvas;
    [SerializeField]
    private TMP_InputField username;
    [SerializeField]
    private TMP_Text score;
  

    [Header("Events")]
    [SerializeField]
    private UnityEvent ScoreSaveSuccessEvent;
    [SerializeField]
    private UnityEvent ScoreSaveFailedEvent;


    [Serializable]
    public class Gamer
    {
        public string new_username;
        public int new_score;
    }

    public void Save()
    {
        string username = this.username.text;
        int score = int.Parse(this.score.text);

        if (this.username.text == "")
        {
            Debug.Log("Must input username");
            ScoreSaveFailedEvent.Invoke();
            missingUsernameErrorCanvas.SetActive(true);
            return;
        }

        Gamer gamer = new Gamer();
        gamer.new_username = username;
        gamer.new_score = score;
       

        string json = JsonUtility.ToJson(gamer);
        StartCoroutine(PutRequest("http://127.0.0.1:5000/scoreboard/1", json));
    }

    public void ClearUsernameField()
    {
        this.username.text = "";
    }

    IEnumerator PutRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "PUT");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {

           
            connectionErrorCanvas.SetActive(true);
            Debug.Log("Error While Sending: " + uwr.error);
        }

        else if (uwr.result == UnityWebRequest.Result.ProtocolError)
        {
            ScoreSaveFailedEvent.Invoke();
            scoreTooLowErrorCanvas.SetActive(true );
        }

        else
        {
            ScoreSaveSuccessEvent.Invoke();
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
