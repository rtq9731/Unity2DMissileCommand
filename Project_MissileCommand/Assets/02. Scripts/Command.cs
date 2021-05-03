using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    [SerializeField] [Header("수비 미사일 날리는 쿨타임")]
    private float missileFireCool;
    private float missileFireTimer;

    private MissileHitScan hitScan;

    private void Start()
    {
        hitScan = transform.GetComponent<MissileHitScan>();
    }

    private void Update()
    {
        if (hitScan.isDead)
            MainSceneManager.Instance.GameOver();
        else
            MainSceneManager.Instance.surviveTime += Time.deltaTime;

        missileFireTimer += Time.deltaTime;
    
        if (missileFireTimer > missileFireCool && Input.GetKey(KeyCode.Z))
        {
            missileFireTimer = 0;
            Debug.Log("수비 미사일 발싸히히!!");
            MainSceneManager.Instance.MakeDefenseMissile();
        }
    }
}
