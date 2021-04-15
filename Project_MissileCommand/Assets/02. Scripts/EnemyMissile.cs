using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMissile : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] [Header("오브젝트의 체력")]
    public int hp = 0;
    [SerializeField] [Header("미사일의 속도")]
    private float speed = 1;
    [SerializeField] [Header("각도 조정을 위한 변수")]
    private float offset = 0;
    [SerializeField] [Header("파티클 시스템")]
    private ParticleSystem particle = null;
    [SerializeField] [Header("파괴 시 줄 점수")]
    private float scoreOfDefense = 0f;

    private Vector2 targetPos = Vector2.zero;
    private Vector2 thisPos = Vector2.zero;

    private Animator animator = null;

    private float angle;
    private float timer;
    private float hitRange = 1.5f;

    public bool isDead = false;
    private bool isFly;
    private bool isDie; 
    public bool isHit;

    void OnEnable()
    {
        timer = 0;
        isFly = true;
        isDie = false;
        isHit = false;

        this.transform.position = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), GameManager.Instance.maxPos.y);
        //타겟 포지션 랜덤 생성
        targetPos = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), GameManager.Instance.minPos.y );

        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        animator = this.transform.GetComponent<Animator>();
        //x -= vx * speed * Time.deltaTime;
        //y -= vy * speed * Time.deltaTime;

    }

    private void Update()
    {

        if (this.transform.position.y < GameManager.Instance.minPos.y && timer > 2f || isHit )
        {
            StartCoroutine(explosion());
            timer = 0;
            isFly = false;
        }
        else if(isFly)
            transform.Translate(Vector2.up * speed * Time.deltaTime);

        timer += Time.deltaTime;
    }

    IEnumerator explosion()
    {
        animator.SetBool("isBoom", true);

        if(!isDie)
        {
            isDie = true;
            GameManager.Instance.score += scoreOfDefense;
            MainSceneManager.Instance.TopUIManager.isDefenseScoreUp = true;
            if (scoreOfDefense == 0)
                Debug.Log(this.gameObject + " = " + "점수가 초기화되지 않았습니다!");
        }

        particle.Stop();
        yield return new WaitForSeconds(1.42f);
        transform.position = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), 7);
        animator.SetBool("isBoom", false);
        this.gameObject.SetActive(false);
        isHit = false;
        isDie = false;
        yield return 0;
    }

}
