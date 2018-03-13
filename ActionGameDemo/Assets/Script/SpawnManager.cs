using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public EnemySpawn[] monsterSpawnList;
    public EnemySpawn[] bossSpawnList;
    private List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        //第一波敌人
        foreach (var pos in monsterSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //第二波敌人
        foreach (var pos in monsterSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (var pos in monsterSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //第三波敌人
        foreach (var pos in monsterSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (var pos in monsterSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (var pos in bossSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }
    }
}
