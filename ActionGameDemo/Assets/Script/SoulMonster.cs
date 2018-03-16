using UnityEngine;
using System.Collections;

public class SoulMonster : MonoBehaviour
{
    public float speed = 3;
    public float attackDistance = 1.0f;
    public float attackInterval = 3.0f;

    private GameObject player;
    private PlayerATKAndDamage playerATKDamage;
    private CharacterController cc;
    private Animator animator;
    private float atkTimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        atkTimer = attackInterval;
        playerATKDamage = player.GetComponent<PlayerATKAndDamage>();
    }

    void Update()
    {
        if (!player ||!playerATKDamage || playerATKDamage.hp <= 0)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        Vector3 targetPos = player.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= attackInterval)
            {
                atkTimer = 0;
                animator.SetTrigger("Attack");
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.Move(transform.forward * Time.deltaTime * speed);
            }
            animator.SetFloat("Speed", 1);
        }
    }
}
