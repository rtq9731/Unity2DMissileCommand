using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public GameObject thisObj;
    public float score;
    public Text scoreText;
    public Text nameText;
    public string name;
    public Text msgText;
    public string msg;

    private void Start()
    {
        scoreText.text = "Score : " + score.ToString();
        nameText.text = "Name : " + score.ToString();
        msgText.text = msg;
    }
    private void OnEnable()
    {
        scoreText.text = "Score : " + score.ToString();
    }

}
