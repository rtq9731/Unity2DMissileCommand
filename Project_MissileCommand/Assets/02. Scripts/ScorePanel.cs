using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public GameObject thisObj;
    public float score;
    public Text scoreText;
    public Text nameText;
    public string playerName;
    public Text msgText;
    public string msg;
    public Text surviveTimeText;
    public float surviveTime = 0;

    public void ReloadData()
    {
        scoreText.text = $"Score : {score}";
        nameText.text = $"Name : {playerName}";
        msgText.text = msg;
        surviveTimeText.text = $"Survive : {surviveTime}s";
    }    

}
