using UnityEngine;
using System.Collections;

public class SoulBoss : MonoBehaviour
{
    public float speed = 2;
    public float attackDistance = 1.5f;
    public float attackInterval = 3.0f;

    private Transform player;
    private PlayerATKAndDamage playerATKDamage;
    private CharacterController cc;
    private Animator animator;
    private float atkTimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        atkTimer = attackInterval;
        playerATKDamage = player.GetComponent<PlayerATKAndDamage>();
    }

    void Update()
    {
        if (!player || !playerATKDamage || playerATKDamage.hp <= 0)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackDistance)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= attackInterval)
            {
                atkTimer = 0;

                if (Random.Range(0.0f, 1.0f) > 0.5f)
                {
                    animator.SetTrigger("Attack1");
                }
                else
                {
                    animator.SetTrigger("Attack2");
                }
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
        else //进行追踪
        {
            atkTimer = attackInterval;//每次追踪到就立即攻击
            //防止在攻击状态移动
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
            {
                cc.Move(transform.forward * Time.deltaTime * speed);
            }
            animator.SetFloat("Speed", 1);
        }
    }
}
