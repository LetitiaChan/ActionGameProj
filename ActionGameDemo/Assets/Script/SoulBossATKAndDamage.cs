using UnityEngine;
using System.Collections;

public class SoulBossATKAndDamage : ATKAndDamage
{
    private GameObject player;

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    public void Attack1()
    {
        AudioManager.PlayAudioEffectB("BossAttack");
        if (player && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            player.GetComponent<PlayerATKAndDamage>().TakeDamage(attackNormal);
        }
    }

    public void Attack2()
    {
        AudioManager.PlayAudioEffectB("BossAttack");
        if (player && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            player.GetComponent<PlayerATKAndDamage>().TakeDamage(attackNormal);
        }
    }
}
