using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class HitScan : MonoBehaviour
{

    [SerializeField]
    [Header("맞았는지 검사할 오브젝트의 태그")]
    private GameManager.typesOfObj tagOfHitScanObject;
    [SerializeField]
    [Header("맞았는지 검사할 범위")]
    private float hitSacnRange = 0f;
    [SerializeField]
    [Header("이 오브젝트의 체력")]
    private float HP = 0f;

    private float notDieTimer = 0;

    private Transform target;

    void Start()
    {
        Debug.LogError(Enum.GetName(typeof(GameManager.typesOfObj), tagOfHitScanObject));
        target = GameObject.FindGameObjectWithTag(Enum.GetName(typeof(GameManager.typesOfObj), tagOfHitScanObject)).GetComponent<Transform>();
    }
 
}
