using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    public float exitTime = 1f;

    void Start()
    {
        Destroy(this.gameObject, exitTime);
    }

}
