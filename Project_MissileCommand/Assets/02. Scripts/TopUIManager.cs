using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopUIManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text hitText;
    [SerializeField]
    private Text incomingMsg;

    public bool isSurviveTimeUp;
    public bool isDefenseScoreUp;

    private void Update()
    {
        if(isSurviveTimeUp)
        timeText.text = "Survive : " + GameManager.Instance.surviveTime;

        if(isDefenseScoreUp)
        hitText.text = "Score : " + GameManager.Instance.score;
    }

    public void incoming()
    {

    }

}
