using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObject : MonoBehaviour
{

    [SerializeField] [Header("������ ������ ���� ����")]
    private float offset = 0;
    [SerializeField] [Header("�ٶ� ����� �±�")]
    private string tagOfLookingObject = "";

    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(tagOfLookingObject).GetComponent<Transform>();
    }

    void Update()
    {
        Lookat();
    }

    private void Lookat()
    {
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
}
