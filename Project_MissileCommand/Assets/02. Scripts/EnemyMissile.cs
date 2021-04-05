using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMissile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Header("미사일의 속도")]
    private float speed = 1;
    [SerializeField] [Header("각도 조정을 위한 변수")]
    private float offset = 0;
    [SerializeField] [Header("폭팔 반경")]
    private float explosionRange = 0;
    [SerializeField]
    private ParticleSystem particle = null;

    private Vector2 targetPos = Vector2.zero;
    private Vector2 thisPos = Vector2.zero;

    private Animator animator = null;

    private float angle;

    void OnEnable()
    {

        //타겟 포지션 랜덤 생성
        targetPos = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), -4.6f);
        Debug.Log(targetPos);

        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        Debug.Log(targetPos);
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        animator = this.transform.GetComponent<Animator>();
        //x -= vx * speed * Time.deltaTime;
        //y -= vy * speed * Time.deltaTime;

    }

    private void Update()
    {

        if (this.transform.position.y < -3f)
            StartCoroutine(explosion());
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    IEnumerator explosion()
    {
        Debug.Log("폭팔");
        animator.SetBool("isBoom", true);
        particle.Stop();
        yield return new WaitForSeconds(1.42f);
        this.gameObject.SetActive(false);

        yield return 0;
    }

}
