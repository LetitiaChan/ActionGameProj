using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    public float speed = 4;
    private CharacterController _cc;
    private Animator _animator;

    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }
    public void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }
    public void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    //移动摇杆结束    
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        //停止时，角色恢复idle    
        if (move.joystickName == "HeroJoystick")
        {
            _animator.SetFloat("Speed", 0);
        }
    }


    //移动摇杆中    
    void OnJoystickMove(MovingJoystick move)
    {
        if (move.joystickName != "HeroJoystick")
        {
            return;
        }

        //获取摇杆中心偏移的坐标    
        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;

        if (joyPositionY != 0 || joyPositionX != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）    
            transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            //移动玩家的位置（按朝向位置移动）    
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //播放奔跑动画    
            _animator.SetFloat("Speed", 1);
        }
    }
}
