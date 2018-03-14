using UnityEngine;
using System.Collections;

public class GunBullet : MonoBehaviour
{
    public float speed = 10f;
    public float attack = 100;

    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.soulBoss || other.tag == Tags.soulMonster)
        {
            other.GetComponent<ATKAndDamage>().TakeDamage(attack);
        }
    }
}
