using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField]
    public TopUIManager TopUIManager;
    [SerializeField]
    private GameObject gameOverPanel;

    private bool isGameover = false;

    public Command command;

    private GameObject missilePrefab;
    private GameObject defenseMissilePrefab;
    public Vector2 cursorPos = Vector2.zero;

    public List<GameObject> missileList = new List<GameObject>();
    public List<GameObject> defenseMissileList = new List<GameObject>();

    static public MainSceneManager Instance = null;

    private int numberOfMissile = 0;
    private int numberOfDefenseMissile = 0;

    public float score = 0;
    public float surviveTime = 0f;

    [SerializeField] [Header("스테이지 당 미사일 생성시간 감소량")]
    private float makeMissileTimeMinus;

    [SerializeField] [Header("미사일 생성 텀")]
    private float makeMissileTime = 0f;

    private float makeMissileTimer = 0f;

    [SerializeField] [Header("스테이지 당 시간")]
    private float stageTime = 0f;

    private float stageTimer = 0f;

    public int cities = 0;

    private void Awake()
    {
        Instance = this;
        isGameover = false;
        Time.timeScale = 1;
        numberOfMissile = 0;
        numberOfDefenseMissile = 0;
        cities = 0;
        missilePrefab = Resources.Load("Missile") as GameObject;
        defenseMissilePrefab = Resources.Load("DefenseMissile") as GameObject;
        missileList = new List<GameObject>();
        defenseMissileList = new List<GameObject>();
        command = FindObjectOfType<Command>();
        DOTween.Clear();
    }
    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
            GameManager.Instance.DeleteSave();
        if (Input.GetKeyDown(KeyCode.Insert))
            FindObjectOfType<GameOverPanel>().CallScoreInput();

        if (makeMissileTimer >= makeMissileTime)
        {
            MakeMissile();
            makeMissileTimer = 0f;
        }
        if(stageTimer >= stageTime)
        {
            makeMissileTime -= makeMissileTimeMinus;
            TopUIManager.DoIncomingText();
            stageTimer = 0f;
        }

        cursorPos = FindObjectOfType<Cursor>().transform.position;

        if(!isGameover)
        {
            makeMissileTimer += Time.deltaTime;
            stageTimer += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); isGameover = true;
    }

    public void MakeMissile()
    {
        if (missileList.Count < 10)
        {
            GameObject temp;
            temp = Instantiate(missilePrefab);
            missileList.Add(temp);
            temp.SetActive(false);
        }

        missileList[numberOfMissile].gameObject.SetActive(true);
        numberOfMissile++;
        if (numberOfMissile == missileList.Count)
            numberOfMissile = 0;

    }

    public void MakeDefenseMissile()
    {
        if (defenseMissileList.Count < 10)
        {
            GameObject temp = null;
            temp = Instantiate(defenseMissilePrefab);
            defenseMissileList.Add(temp);
            temp.SetActive(false);
        }

        defenseMissileList[numberOfDefenseMissile].gameObject.SetActive(true);
        numberOfDefenseMissile++;
        if (numberOfDefenseMissile == defenseMissileList.Count)
            numberOfDefenseMissile = 0;

    }

}
