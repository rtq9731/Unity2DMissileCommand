using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class HitScan : MonoBehaviour
{

    [SerializeField]
    [Header("�¾Ҵ��� �˻��� ������Ʈ�� �±�")]
    private GameManager.typesOfObj tagOfHitScanObject;
    [SerializeField]
    [Header("�¾Ҵ��� �˻��� ����")]
    private float hitSacnRange = 0f;
    [SerializeField]
    [Header("�� ������Ʈ�� ü��")]
    private float HP = 0f;

    private float notDieTimer = 0;

    private Transform target;

    void Start()
    {
        Debug.LogError(Enum.GetName(typeof(GameManager.typesOfObj), tagOfHitScanObject));
        target = GameObject.FindGameObjectWithTag(Enum.GetName(typeof(GameManager.typesOfObj), tagOfHitScanObject)).GetComponent<Transform>();
    }
 
}
