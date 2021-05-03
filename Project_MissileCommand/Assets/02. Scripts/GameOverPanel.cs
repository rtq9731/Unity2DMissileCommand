using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button quitBtn;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField] RecordScoreInput input;
    [SerializeField] GameObject leaderBorad; // 부모오브젝트 ( 스크롤뷰의 콘텐츠 )

    private GameObject scorePanelResource = null;

    private List<GameObject> scorePanels = new List<GameObject>();

    GameObject temp = null;

    private void Awake()
    {
        restartBtn.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
        quitBtn.onClick.AddListener(() => Application.Quit());
        input.cancelBtn.onClick.AddListener(() => DeleteInput());
        input.okBtn.onClick.AddListener(InputData);
        scorePanelResource = (GameObject)Resources.Load("ScorePanel");
    }

    private void InputData()
    {
        if (scorePanels.Count < 5) // 스코어 판넬의 개수가 5개 이하라면 생성
        {
            MakeScorePanel(MainSceneManager.Instance.score);
        }
        else // 5개 보다 많다면 정렬 후 가장 낮은 점수의 스코어 판넬의 데이터를 바꿔치기
        {
            SortScorePanels();

            GameObject tempObj = scorePanels[4].GetComponent<ScorePanel>().gameObject;

            InputDataToPanel(scorePanels[4].GetComponent<ScorePanel>(),
                new DataClass(input.nameInput.text.ToString(), MainSceneManager.Instance.score, input.msgInput.text.ToString(), MainSceneManager.Instance.surviveTime));

            tempObj.transform.SetSiblingIndex(scorePanels.IndexOf(tempObj));
            GameManager.Instance.SaveData();
            DeleteInput();
            return;
        }

        SortScorePanels();

        DataClass data = new DataClass(input.nameInput.text.ToString(), MainSceneManager.Instance.score, input.msgInput.text.ToString(), MainSceneManager.Instance.surviveTime);
        GameManager.Instance.datas.Add(data);
        temp.transform.SetSiblingIndex(scorePanels.IndexOf(temp));
        InputDataToPanel(temp.GetComponent<ScorePanel>(), data);
        GameManager.Instance.SaveData();
        DeleteInput();
    }

    private void InputDataToPanel(ScorePanel currentScorePanel, DataClass data)
    {
        currentScorePanel.score = data.score;
        currentScorePanel.msg = data.msg;
        currentScorePanel.playerName = data.name;
        currentScorePanel.ReloadData();
    }

    private void SortScorePanels()
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
    }

    private void MakeScorePanel(float score)
    {
        temp = Instantiate(scorePanelResource);
        temp.transform.SetParent(leaderBorad.transform);
        temp.GetComponent<ScorePanel>().score = score;
        temp.transform.localScale = new Vector3(1, 1, 1);
        scorePanels.Add(temp);
        temp.SetActive(true);
    }

    public void CallScoreInput()
    {
        input.gameObject.SetActive(true);
        input.GetComponent<RectTransform>().DOAnchorPosY(0, 1).SetEase(Ease.OutQuad);
    }

    private void LoadLeaderBoard()
    {
        foreach (var item in GameManager.Instance.datas)
        {
            
        }
    }

    private void DeleteInput()
    {
        input.GetComponent<RectTransform>().DOAnchorPosY(800, 1).SetEase(Ease.InOutQuart);
        input.nameInput.text = "";
        input.msgInput.text = "";
        Invoke(nameof(InputActiveFalse), 2);
    }
    private void InputActiveFalse()
    {
        input.gameObject.SetActive(false);
        DOTween.Clear();
    }

    private void OnEnable()
    {
        scoreText.text = "ScoreText : " + MainSceneManager.Instance.score.ToString();
        timeText.text = "Survive Time : " + MainSceneManager.Instance.surviveTime.ToString();

        SortScorePanels();
        CallScoreInput();
    }

}
