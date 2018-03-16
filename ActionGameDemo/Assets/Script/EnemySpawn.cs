using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;

    public GameObject Spawn()
    {
        Vector3 targetPos = transform.position;
        targetPos.x += Random.Range(-2.0f, 2.0f);
        targetPos.z += Random.Range(-2.0f, 2.0f);
        return GameObject.Instantiate(prefab, targetPos, transform.rotation) as GameObject;
    }
}
