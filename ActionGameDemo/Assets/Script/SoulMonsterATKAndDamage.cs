using UnityEngine;
using System.Collections;

public class SoulMonsterATKAndDamage : ATKAndDamage
{
    private GameObject player;

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    public void MonsterAttack()
    {
        if (player && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            player.GetComponent<PlayerATKAndDamage>().TakeDamage(attackNormal);
        }
    }
}
