using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    [Header("Level Name")]
    [SerializeField]
    private string sceneName;


   public void ChooseLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
