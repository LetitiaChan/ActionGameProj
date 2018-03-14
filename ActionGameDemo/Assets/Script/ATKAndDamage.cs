using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100;
    public float attackNormal = 50;
    public float attackDistance = 1.5f;
    protected Animator animator;
    private bool isOnceDead = false;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
            hp -= damage;

        if (gameObject.tag == Tags.soulBoss || gameObject.tag == Tags.soulMonster)
            print("TakeDamage()/" + gameObject.tag + "  hp = " + hp + ", damage =" + damage);

        if (hp > 0)
        {
            if (gameObject.tag == Tags.soulBoss || gameObject.tag == Tags.soulMonster)
            {
                animator.SetTrigger("Damage");
            }
        }
        else
        {
            if (!isOnceDead)
            {
                isOnceDead = true;
                animator.SetTrigger("Dead");
                Destroy(this.gameObject, 1);
                this.GetComponent<CharacterController>().enabled = false;
                if (gameObject.tag == Tags.soulBoss || gameObject.tag == Tags.soulMonster)
                {
                    SpawnManager.Instance.enemyList.Remove(this.gameObject);
                }
            }
        }

        if (this.gameObject.tag == Tags.soulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        }
        else if (this.gameObject.tag == Tags.soulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up / 2, transform.rotation);
        }
    }
}
