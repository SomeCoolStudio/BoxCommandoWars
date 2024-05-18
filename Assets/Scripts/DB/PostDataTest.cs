using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class PostMe : MonoBehaviour
{

    public TMP_InputField username;
    public TMP_InputField score;

    [Serializable]
    public class Gamer
    {
        public string username;
        public int score;
    }

    public void PostData()
    {
        string username = this.username.text;
        int score = int.Parse(this.score.text);

        Gamer gamer = new Gamer();
        gamer.username = username;
        gamer.score = score;

        string json = JsonUtility.ToJson(gamer);
        StartCoroutine(PostRequest("http://127.0.0.1:5000/item", json));
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
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}