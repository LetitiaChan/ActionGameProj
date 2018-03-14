using UnityEngine;
using System.Collections;

public enum AwardType
{
    Gun,
    DualSword
}

public class AwardItem : MonoBehaviour
{
    public AwardType type;
    public float speed = 10;
    private Rigidbody rigid;
    private bool isStartMove = false;
    private GameObject player;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }

    void Update()
    {
        if (isStartMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + Vector3.up, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, player.transform.position + Vector3.up) < 0.5f)
            {
                player.GetComponent<PlayerPickItem>().PickUpItem(type);
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.ground)
        {
            rigid.useGravity = false;
            rigid.isKinematic = true;
            SphereCollider col = GetComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = 4;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            isStartMove = true;
            player = other.gameObject;
        }
    }
}
