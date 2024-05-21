using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;


public class GetLeaderboardData : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private GameObject connectionErrorCanvas;
    [SerializeField]
    private TMP_Text firstPlaceUsername;
    [SerializeField]
    private TMP_Text secondPlaceUsername;
    [SerializeField]
    private TMP_Text thirdPlaceUsername;
    [SerializeField]
    private TMP_Text firstPlaceScore;
    [SerializeField]
    private TMP_Text secondPlaceScore;
    [SerializeField]
    private TMP_Text thirdPlaceScore;


    [Header("Events")]
    [SerializeField]
    private UnityEvent ScoreSaveSuccessEvent;
    [SerializeField]
    private UnityEvent ScoreSaveFailedEvent;

    [Serializable]
    public class UserObject
    {
        public int score;
        public string username;
    }

    [Serializable]
    public class UserList
    {
        public List<UserObject> username;
    }




    private void Start()
    {
        GetData();

    }



    public void GetData()
    {
        StartCoroutine(GetRequest("https://box-commando-flask-deploy.onrender.com/scoreboard/1"));
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {

            char[] delimiterChars = { ',', ':' };
            string[] newResults = uwr.downloadHandler.text.Split(delimiterChars);
            
            firstPlaceScore.text = newResults[1];
            firstPlaceUsername.text = newResults[3].Replace('"', ' '); ;
            secondPlaceScore.text = newResults[13];
            secondPlaceUsername.text = newResults[15].Replace('"', ' '); ;
            thirdPlaceScore.text = newResults[17];
            thirdPlaceUsername.text = newResults[19].Replace("}", "").Replace('"', ' ');
        }
    }
}



