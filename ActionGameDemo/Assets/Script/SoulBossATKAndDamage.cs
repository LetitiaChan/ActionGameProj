using UnityEngine;
using System.Collections;

public class SoulBossATKAndDamage : ATKAndDamage
{
    private GameObject player;

    void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    public void Attack1()
    {
        AudioManager.PlayAudioEffectB("BossAttack");
        if (player && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(attackNormal);
        }
    }

    public void Attack2()
    {
        AudioManager.PlayAudioEffectB("BossAttack");
        if (player && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(attackNormal);
        }
    }
}
