using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private GameObject missilePrefab;

    static public EnemyManager Instance = null;

    private int numberOfMissile = 0;

    [SerializeField] [Header("미사일 생성 텀")]
    private float makeMissileTime = 0f;

    private float makeMIssileTimer = 0f;

    private void Awake()
    {
        if (Instance = null)
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
        if (makeMIssileTimer >= makeMissileTime)
        {
            MakeMissile();
            makeMIssileTimer = 0f;
        }

        makeMIssileTimer += Time.deltaTime;
    }

    private void Start()
    {
        missilePrefab = Resources.Load("Missile") as GameObject;
    }

    public void MakeMissile()
    {

        if (GameManager.Instance.missileList.Count < 10)
        {
            GameObject temp = null;
            temp = Instantiate(missilePrefab);
            GameManager.Instance.missileList.Add(temp);
            temp.SetActive(false);
        }

        GameManager.Instance.missileList[numberOfMissile].gameObject.SetActive(true);
        numberOfMissile++;
        if (numberOfMissile == GameManager.Instance.missileList.Count)
            numberOfMissile = 0;

    }

}
