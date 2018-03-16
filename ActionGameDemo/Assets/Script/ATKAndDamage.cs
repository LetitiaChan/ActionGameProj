using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100;
    public float attackNormal = 50;
    public float attackDistance = 1.5f;
    protected Animator animator;
    private bool isOnceDead = false;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
            hp -= damage;

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

                if (gameObject.tag == Tags.soulMonster)
                    AudioManager.PlayAudioEffectB("MonterDeath");
                else if (gameObject.tag == Tags.soulBoss)
                    AudioManager.PlayAudioEffectB("BossDeath");
                else if (gameObject.tag == Tags.player)
                    SceneMgr.Instance.IsPlayerAlive = false;

                animator.SetTrigger("Dead");
                this.GetComponent<CharacterController>().enabled = false;

                if (gameObject.tag == Tags.soulBoss || gameObject.tag == Tags.soulMonster)
                {
                    Destroy(this.gameObject, 1);
                    SpawnAward();
                    SpawnManager.Instance.enemyList.Remove(this.gameObject);
                }
            }
        }

        if (this.gameObject.tag == Tags.soulBoss)
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        else if (this.gameObject.tag == Tags.soulMonster)
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up / 2, transform.rotation);
    }

    void SpawnAward()
    {
        int count = Random.Range(0, 2);
        for (int i = 0; i < count; i++)
        {
            if (Random.Range(0, 2) == 0)
                GameObject.Instantiate(Resources.Load("Item_DualSword"), transform.position + Vector3.up, Quaternion.identity);
            else
                GameObject.Instantiate(Resources.Load("Item_Gun"), transform.position + Vector3.up, Quaternion.identity);

        }
    }
}
