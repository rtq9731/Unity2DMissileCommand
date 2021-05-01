using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    Button restartBtn;
    [SerializeField]
    Button quitBtn;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text timeText;

    [SerializeField]
    RecordScoreInput input;
    [SerializeField]
    GameObject leaderBorad; // 부모오브젝트 ( 스크롤뷰의 콘텐츠 )

    private List<GameObject> scorePanels = new List<GameObject>();

    private GameObject scorePanelResource = null;

    private void Awake()
    {
        restartBtn.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
        quitBtn.onClick.AddListener(() => Application.Quit());
        input.cancelBtn.onClick.AddListener(() => input.gameObject.SetActive(false));
        input.okBtn.onClick.AddListener(InputData);
        scorePanelResource = (GameObject)Resources.Load("ScorePanel");
        input = FindObjectOfType<RecordScoreInput>();
    }

    private void InputData()
    {
        GameObject temp = null;
        if (scorePanels.Count < 5)
        {
            temp = Instantiate(scorePanelResource);
            temp.SetActive(true);
            temp.transform.SetParent(leaderBorad.transform);
            temp.GetComponent<ScorePanel>().score = MainSceneManager.Instance.score;
            temp.transform.localScale = new Vector3(1, 1, 1);
            scorePanels.Add(temp);
        }
        else
        {
            scorePanels.Sort((x, y) =>
            {
                if (x.GetComponent<ScorePanel>().score > y.GetComponent<ScorePanel>().score)
                    return 1;
                else if (x.GetComponent<ScorePanel>().score == y.GetComponent<ScorePanel>().score)
                    return 0;
                else if (x.GetComponent<ScorePanel>().score < y.GetComponent<ScorePanel>().score)
                    return -1;

                return 0;
            });

            ScorePanel temp1 = scorePanels[4].GetComponent<ScorePanel>();

            temp1.score = MainSceneManager.Instance.score;
            temp1.msg = input.msgInput.ToString();
            temp1.name = input.nameInput.ToString();

            temp.transform.SetSiblingIndex(scorePanels.IndexOf(temp));

            return;
        }
        ScorePanel currentScorePanel = temp.GetComponent<ScorePanel>();


        scorePanels.Sort((x, y) =>
        {
            if (x.GetComponent<ScorePanel>().score > y.GetComponent<ScorePanel>().score)
                return 1;
            else if (x.GetComponent<ScorePanel>().score == y.GetComponent<ScorePanel>().score)
                return 0;
            else if (x.GetComponent<ScorePanel>().score < y.GetComponent<ScorePanel>().score)
                return -1;

            return 0;
        });

        temp.transform.SetSiblingIndex(scorePanels.IndexOf(temp));
        currentScorePanel.score = MainSceneManager.Instance.score;
        currentScorePanel.msg = input.msgInput.ToString();
        currentScorePanel.name = input.nameInput.ToString();
    }

    private void OnEnable()
    {
        scoreText.text = "ScoreText : " + MainSceneManager.Instance.score.ToString();
        timeText.text = "Survive Time : " + MainSceneManager.Instance.surviveTime.ToString();
    }

}
