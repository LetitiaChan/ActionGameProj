using UnityEngine;
using System.Collections;

public class UIAttack : MonoBehaviour
{
    public static UIAttack Instance;
    public GameObject btnATKNormal;
    public GameObject btnATKRange;
    public GameObject btnATKGun;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        btnATKNormal = transform.FindChild("btnATKNormal").gameObject;
        btnATKRange = transform.FindChild("btnATKRange").gameObject;
        btnATKGun = transform.FindChild("btnATKRed").gameObject;
    }

    public void TurnToGunkAttack()
    {
        btnATKNormal.SetActive(false);
        btnATKRange.SetActive(false);
        btnATKGun.SetActive(true);
    }

    public void TurnToSwordAttack()
    {
        btnATKNormal.SetActive(true);
        btnATKRange.SetActive(true);
        btnATKGun.SetActive(false);
    }
}
