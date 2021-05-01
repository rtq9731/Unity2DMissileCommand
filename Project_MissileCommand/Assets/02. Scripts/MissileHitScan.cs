using System.Collections;
using UnityEngine;

public class MissileHitScan : MonoBehaviour
{
    [SerializeField] [Header("오브젝트의 체력")]
    public int hp = 0;

    private float hitRange = 1.5f;

    private Animator animator = null;

    public bool isDead = false;

    private void Start()
    {
        animator = transform.GetComponent<Animator>();
        MainSceneManager.Instance.cities++;
    }

    private void Update()
    {
        foreach (var item in MainSceneManager.Instance.missileList)
        {
            if (item == null)
                break;
            if (Vector2.Distance(item.transform.position, transform.position) <= hitRange && item.gameObject.activeSelf && !item.GetComponent<EnemyMissile>().isHit)
            {
                item.GetComponent<EnemyMissile>().isHit = true;
                hp--;
                if (hp <= 0 && !animator.GetBool("isDead"))
                    StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        animator.SetBool("isDead", true);
        MainSceneManager.Instance.cities--;
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("isDead", false);
        isDead = true;
        gameObject.SetActive(false);
    }

}
