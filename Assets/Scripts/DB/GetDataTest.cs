using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetDataTest : MonoBehaviour
{


    public void GetData()
    {
        StartCoroutine(GetRequest("http://127.0.0.1:5000/user/3"));
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
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}