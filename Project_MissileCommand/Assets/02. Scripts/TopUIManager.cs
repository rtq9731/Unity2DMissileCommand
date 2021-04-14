using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TopUIManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text hitText;
    [SerializeField]
    private Text incomingMsg;
    [SerializeField] [Header("경고 문구가 타이핑 되는데 걸리는 시간")]
    private float AnimationTimeOfIncomingMsg;

    public bool isDefenseScoreUp;

    private void Update()
    {
        timeText.text = "Survive : " + string.Format("{0:0.#}", GameManager.Instance.surviveTime);

        if(isDefenseScoreUp)
        hitText.text = "Score : " + GameManager.Instance.score;
    }

    public void incoming()
    {
        incomingMsg.DOText("경고 ! 더 많은 미사일이 다가옵니다!", AnimationTimeOfIncomingMsg);
    }

}
