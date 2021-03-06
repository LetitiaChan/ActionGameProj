﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerATKAndDamage : ATKAndDamage
{
    public float attackB = 80;
    public float attackRange = 100;
    public float attackGun = 100;
    public WeaponGun gun;

    public void AttackA()
    {
        if (SpawnManager.Instance == null) return;

        //找到攻击范围内的最近敌人
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (var go in SpawnManager.Instance.enemyList)
        {
            var goPos = go.transform.position;
            goPos.y = transform.position.y;
            var temp = Vector3.Distance(goPos, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }

        if (enemy && enemy.GetComponent<ATKAndDamage>())
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);

            AudioManager.PlayAudioEffectA("PlayerSwordSwing");
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackNormal);
        }
    }

    public void AttackB()
    {
        if (SpawnManager.Instance == null) return;
        //找到攻击范围内的最近敌人
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (var go in SpawnManager.Instance.enemyList)
        {
            var goPos = go.transform.position;
            goPos.y = transform.position.y;
            var temp = Vector3.Distance(goPos, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }

        if (enemy && enemy.GetComponent<ATKAndDamage>())
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);

            AudioManager.PlayAudioEffectA("PlayerSwordSwing");
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    }

    public void AttackRange()
    {
        if (SpawnManager.Instance == null) return;
        List<GameObject> enemyInRange = new List<GameObject>();
        foreach (var go in SpawnManager.Instance.enemyList)
        {
            var goPos = go.transform.position;
            goPos.y = transform.position.y;
            if (Vector3.Distance(goPos, transform.position) < attackDistance)
            {
                enemyInRange.Add(go);
            }
        }
        AudioManager.PlayAudioEffectA("PlayerSwordSwing");
        foreach (var enemy in enemyInRange)
        {
            if (enemy && enemy.GetComponent<ATKAndDamage>())
                enemy.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }

    public void AttackGun()
    {
        AudioManager.PlayAudioEffectA("PlayerGunShot");
        gun.attack = attackGun;
        gun.Shoot();
    }
}
