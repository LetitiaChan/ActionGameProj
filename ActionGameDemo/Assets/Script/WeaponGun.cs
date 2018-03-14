using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bulletPrefabs;
    public float attack = 100;

    public void Shoot()
    {
        GameObject go = GameObject.Instantiate(bulletPrefabs, bulletPos.position, transform.rotation) as GameObject;
        go.GetComponent<GunBullet>().attack = attack;
    }
}
