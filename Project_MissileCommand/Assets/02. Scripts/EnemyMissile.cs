using System.Collections;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{

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

    private bool isFly;
    public bool isDie;
    public bool isScoreUp = false;

    void OnEnable()
    {
        timer = 0;
        isFly = true;
        isDie = false;

        this.transform.position = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), GameManager.Instance.maxPos.y); //타겟 포지션 랜덤 생성
        targetPos = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), GameManager.Instance.minPos.y );

        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        animator = this.transform.GetComponent<Animator>();
    }

    private void Update()
    {

        if (this.transform.position.y < GameManager.Instance.minPos.y && timer > 2f)
        {
            StartCoroutine(explosion(false));
            timer = 0;
            isFly = false;
        }
        else if(isFly)
            transform.Translate(Vector2.up * speed * Time.deltaTime);

        timer += Time.deltaTime;
    }

    public IEnumerator explosion(bool isDefense)
    {
        animator.SetBool("isBoom", true);

        isFly = false;
        if (!isDie && isDefense)
        {
            MainSceneManager.Instance.score += scoreOfDefense;
            MainSceneManager.Instance.TopUIManager.isDefenseScoreUp = true;
            if (scoreOfDefense == 0)
                Debug.Log(this.gameObject + " = " + "점수가 초기화되지 않았습니다!");
        }
        isDie = true;

        particle.Stop();
        yield return new WaitForSeconds(1.42f);
        transform.position = new Vector2(UnityEngine.Random.Range(GameManager.Instance.minPos.x, GameManager.Instance.maxPos.x), 7);
        animator.SetBool("isBoom", false);
        this.gameObject.SetActive(false);
        isDie = false;
        yield return 0;
    }

}
