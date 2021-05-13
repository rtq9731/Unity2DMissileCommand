using System.Collections;
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
    private Vector2 firstTargetPos = Vector2.zero;

    private bool isDead = false;

    private void OnEnable()
    {
        this.transform.position = MainSceneManager.Instance.command.gameObject.transform.position;
        targetPos = MainSceneManager.Instance.cursorPos;
        firstTargetPos = MainSceneManager.Instance.cursorPos;


        targetPos.x = targetPos.x - transform.position.x;
        targetPos.y = targetPos.y - transform.position.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }

    private void Update()
    {
        
        if(!isDead)
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        foreach (GameObject item in MainSceneManager.Instance.missileList)
        {
            if(isDead && Vector2.Distance(this.gameObject.transform.position, item.transform.position) <= defenseRange)
            {
                item.gameObject.GetComponent<EnemyMissile>().StartCoroutine(item.gameObject.GetComponent<EnemyMissile>().explosion(true));
            }
        }

        if (transform.position.x > GameManager.Instance.maxPos.x || transform.position.y > GameManager.Instance.maxPos.y 
            || transform.position.x < GameManager.Instance.minPos.x || transform.position.y < GameManager.Instance.minPos.y
            || Vector2.Distance(firstTargetPos, this.transform.position) <= 0.1f)
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
