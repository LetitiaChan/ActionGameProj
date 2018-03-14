using UnityEngine;
using System.Collections;

public class PlayerPickItem : MonoBehaviour
{
    public GameObject goSingleSword;
    public GameObject goDualSword;
    public GameObject goGun;

    public float existTime = 10;
    private float dualSwordTimer = 0;
    private float gunTimer = 0;

    void Update()
    {
        if (dualSwordTimer > 0)
        {
            dualSwordTimer -= Time.deltaTime;
            if (dualSwordTimer <= 0)
                TurnToSingleSword();
        }

        if (gunTimer > 0)
        {
            gunTimer -= Time.deltaTime;
            if (gunTimer <= 0)
                TurnToSingleSword();
        }
    }

    public void PickUpItem(AwardType type)
    {
        switch (type)
        {
            case AwardType.Gun:
                TurnToGun();
                break;
            case AwardType.DualSword:
                TurnToDualSword();
                break;
            default:
                break;
        }
    }

    void TurnToSingleSword()
    {
        goSingleSword.SetActive(true);
        goDualSword.SetActive(false);
        goGun.SetActive(false);
        dualSwordTimer = 0;
        gunTimer = 0;
        UIAttack.Instance.TurnToSwordAttack();
    }
    void TurnToDualSword()
    {
        goSingleSword.SetActive(false);
        goDualSword.SetActive(true);
        goGun.SetActive(false);
        dualSwordTimer = existTime;
        gunTimer = 0;
        UIAttack.Instance.TurnToSwordAttack();
    }

    void TurnToGun()
    {
        goSingleSword.SetActive(false);
        goDualSword.SetActive(false);
        goGun.SetActive(true);
        gunTimer = existTime;
        dualSwordTimer = 0;
        UIAttack.Instance.TurnToGunkAttack();
    }

}
