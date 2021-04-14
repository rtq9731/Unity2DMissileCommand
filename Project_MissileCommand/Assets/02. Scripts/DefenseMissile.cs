using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseMissile : MonoBehaviour
{
    [SerializeField] [Header("미사일의 속도")]
    private float speed = 0f;
    [SerializeField] [Header("각도 조정을 위한 변수")]
    private float offset = 0f;
    [SerializeField] [Header("폭팔 반경")]
    private float defenseRange = 0f;

    private float angle = 0f;

    public Vector2 targetPos = Vector2.zero;

    private bool isDead = false;
    private bool isHit = false;

    private void OnEnable()
    {
        this.transform.position = MainSceneManager.Instance.command.gameObject.transform.position;
        targetPos = MainSceneManager.Instance.cursorPos;

        targetPos.x = targetPos.x - transform.position.x;
        targetPos.y = targetPos.y - transform.position.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }

    private void Update()
    {
        foreach (var item in GameManager.Instance.missileList)
        {

            if (transform.rotation.z <= Quaternion.Euler(0, 0, 90).z)
            {
                if (transform.position.x < targetPos.x && transform.position.y > targetPos.y)
                {
                    StartCoroutine(Die());
                }
            }
            else if (transform.rotation.z < Quaternion.Euler(0, 0, 0).z)
            {
                if (transform.position.x > targetPos.x && transform.position.y > targetPos.y)
                {
                    StartCoroutine(Die());
                }
            }
            else if (transform.rotation.z == Quaternion.Euler(0, 0, 0).z)
            {
                if (transform.position.y > targetPos.y)
                {
                    StartCoroutine(Die());
                }
            }

            if (isDead && Vector2.Distance(this.transform.position, item.transform.position) <= defenseRange)
            {
                item.GetComponent<EnemyMissile>().isHit = true;
            }

        }

        if(!isDead)
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.x > GameManager.Instance.maxPos.x || transform.position.y > GameManager.Instance.maxPos.y || transform.position.x < GameManager.Instance.minPos.x || transform.position.y < GameManager.Instance.minPos.y)
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        gameObject.transform.GetComponent<Animator>().SetBool("isBoom", true);
        isDead = true;
        yield return new WaitForSeconds(1.3f);
        isDead = false;
        gameObject.SetActive(false);
    }

}
