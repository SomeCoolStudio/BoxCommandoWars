using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{


    [SerializeField]
    private TMP_Text score;

    [SerializeField]
    private IntVariable currentScore;

    public void ScoreSetter()
    {
        this.score.text = currentScore.Value.ToString();
    }
}
