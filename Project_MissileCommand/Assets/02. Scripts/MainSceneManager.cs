using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField]
    public TopUIManager TopUIManager;
    [SerializeField]
    private GameObject gameOverPanel;

    public Command command;

    private GameObject missilePrefab;
    private GameObject defenseMissilePrefab;
    public Vector2 cursorPos = Vector2.zero; 

    static public MainSceneManager Instance = null;

    private int numberOfMissile = 0;
    private int numberOfDefenseMissile = 0;

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
        command = FindObjectOfType<Command>();
    }
    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
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
        makeMissileTimer += Time.deltaTime;
        stageTimer += Time.deltaTime;
    }

    private void Start()
    {
        missilePrefab = Resources.Load("Missile") as GameObject;
        defenseMissilePrefab = Resources.Load("DefenseMissile") as GameObject;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void MakeMissile()
    {
        if (GameManager.Instance.missileList.Count < 10)
        {
            GameObject temp;
            temp = Instantiate(missilePrefab);
            GameManager.Instance.missileList.Add(temp);
            temp.SetActive(false);
        }

        GameManager.Instance.missileList[numberOfMissile].gameObject.SetActive(true);
        numberOfMissile++;
        if (numberOfMissile == GameManager.Instance.missileList.Count)
            numberOfMissile = 0;

    }

    public void MakeDefenseMissile()
    {
        if (GameManager.Instance.defenseMissileList.Count < 10)
        {
            GameObject temp = null;
            temp = Instantiate(defenseMissilePrefab);
            GameManager.Instance.defenseMissileList.Add(temp);
            temp.SetActive(false);
        }

        GameManager.Instance.defenseMissileList[numberOfDefenseMissile].gameObject.SetActive(true);
        numberOfDefenseMissile++;
        if (numberOfDefenseMissile == GameManager.Instance.defenseMissileList.Count)
            numberOfDefenseMissile = 0;

    }

}
