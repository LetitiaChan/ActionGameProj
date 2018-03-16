using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public EnemySpawn[] monsterSpawnList;
    public EnemySpawn[] bossSpawnList;
    public List<GameObject> enemyList = new List<GameObject>();

    [HideInInspector]
    public bool IsFinishSpwan = false;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        //The first batch of enemy
        foreach (var pos in monsterSpawnList)
        {
            enemyList.Add(pos.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //The second batch of enemy
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
        //The third batch of enemy
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
        IsFinishSpwan = true;
    }
}
