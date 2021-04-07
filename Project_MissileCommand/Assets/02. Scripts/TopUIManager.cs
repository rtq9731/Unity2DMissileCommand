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

    private void Update()
    {
        timeText.text = "Survive : " + GameManager.Instance.surviveTime;
        hitText.text = "Score : " + GameManager.Instance.score;
    }

}
