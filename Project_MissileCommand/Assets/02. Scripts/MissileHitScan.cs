using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations;

public class MissileHitScan : MonoBehaviour
{
    [SerializeField] [Header("오브젝트의 체력")]
    private int hp;

    private float hitRange = 1.5f;

    private void Update()
    {
        foreach (var item in GameManager.Instance.missileList)
        {
            if (Vector2.Distance(item.transform.position, transform.position) <= hitRange && item.gameObject.activeSelf && !item.GetComponent<EnemyMissile>().isHit)
            {
                Debug.Log("HIT!");
                item.GetComponent<EnemyMissile>().isHit = true;
                hp--;
                if (hp <= 0)
                    StartCoroutine(Die());

            }
        }
    }

    private IEnumerator Die()
    {
        gameObject.transform.GetComponent<Animator>().SetBool("isDead", true);
        yield return new WaitForSeconds(1.3f);
        gameObject.SetActive(false);
    }

}
