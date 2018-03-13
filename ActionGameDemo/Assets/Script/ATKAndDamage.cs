using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100;
    public float normalAttack = 50;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
            hp -= damage;

        if (hp > 0)
        {
            animator.SetTrigger("Damage");
            if (this.gameObject.tag == Tags.soulBoss)
            {
                GameObject.Instantiate(Resources.Load("HitBoss"), transform.position, transform.rotation);
            }
            else if (this.gameObject.tag == Tags.soulMonster)
            {
                GameObject.Instantiate(Resources.Load("HitMonster"), transform.position, transform.rotation);
            }
        }
        else
        {
            animator.SetBool("Dead", true);
        }
    }
}
