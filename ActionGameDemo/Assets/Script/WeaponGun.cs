using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bulletPrefabs;
    public float attack = 100;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    public void Shoot()
    {
        GameObject go = GameObject.Instantiate(bulletPrefabs, bulletPos.position, player.transform.rotation) as GameObject;
        go.GetComponent<GunBullet>().attack = attack;
    }
}
