using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

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
    }

    private void Update()
    {
        foreach (var item in GameManager.Instance.missileList)
        {
            if (Vector2.Distance(item.transform.position, transform.position) <= hitRange && item.gameObject.activeSelf && !item.GetComponent<EnemyMissile>().isHit)
            {
                item.GetComponent<EnemyMissile>().isHit = true;
                hp--;
                if (hp <= 0)
                    StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("isDead", false);
        isDead = true;
        gameObject.SetActive(false);
    }

}
