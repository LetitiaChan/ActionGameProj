using UnityEngine;
using System.Collections;

public class SymbolEnemy : MonoBehaviour
{
    private GameObject symbolEnemy;
    private GameObject player;

    void Start()
    {
        if (gameObject.tag == Tags.soulBoss)
            symbolEnemy = MiniMap.Instance.GetSymbolBoss();
        else if (gameObject.tag == Tags.soulMonster)
            symbolEnemy = MiniMap.Instance.GetSymbolMonster();

        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void Update()
    {
        float zoomFactor = 10;
        Vector3 offset = transform.position - player.transform.position;
        offset *= zoomFactor;
        symbolEnemy.transform.localPosition = new Vector3(offset.x, offset.z, 0);
    }

    void OnDestroy()
    {
        if (symbolEnemy)
            Destroy(symbolEnemy);
    }
}
