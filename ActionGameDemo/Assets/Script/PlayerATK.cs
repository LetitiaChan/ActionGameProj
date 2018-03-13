using UnityEngine;
using System.Collections;

public class PlayerATK : MonoBehaviour
{
    private CharacterController _cc;
    private Animator _animator;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    public void ATKNormal()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA"))
            _animator.SetTrigger("AttackB");
        else
            _animator.SetTrigger("AttackA");
    }
    public void ATKRed()
    {
        _animator.SetTrigger("AttackGun");
    }
    public void ATKRange()
    {
        _animator.SetTrigger("AttackRange");
    }


}
