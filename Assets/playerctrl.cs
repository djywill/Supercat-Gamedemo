using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerctrl : MonoBehaviour
{
    public static playerctrl instance;
    public int speedBoost;
    public int jumpForce;
    public int jumptimes=0;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    bool isJumping;
    bool leftPressed, rightPressed;
    bool Bullet=false;
    public Transform leftBulletSpawnPos;
    public Transform rightBulletSpawnPos;
    
    public GameObject leftBullet;
    public GameObject rightBullet;
    public static bool is_trigger = false;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = Input.GetAxisRaw("Horizontal");//取得键位
        playerSpeed *= speedBoost;

        if (playerSpeed != 0)//当角色速度不为0时
        {
            MoveHorizontal(playerSpeed);//使角色在速度方向有位移
        }
        else
            StopMoving();//停止移动
        if (Input.GetButtonDown("Jump"))//当键盘收到跳跃信号时
        {
            Jump();//跳跃
        }
        Falling();
        if (Input.GetButtonDown("Fire1"))//当键盘收到开火信号时
        {
            Fire();//发射子弹
        }
        if(leftPressed==true)//当左按键标记被激活
        {
            MoveHorizontal(-speedBoost);//使角色在速度的反方向有位移
        }
        else if (rightPressed == true)//当右按键标记被激活
        {
            MoveHorizontal(speedBoost);//使角色在速度方向有位移
        }
    }

    void MoveHorizontal(float playerSpeed)
    {

        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);//使角色在速度方向有唯位移
        if (playerSpeed < 0)//当角色速度小于0时
        {
            sr.flipX = true;//使角色反转
        }
        else if (playerSpeed > 0)//当角色速度大于0时
        {
            sr.flipX = false;//角色不反转
        }
        if (!isJumping)//当角色不在跳跃状态
            anim.SetInteger("State", 1);//动画机state值为1
    }

    void Jump()
    {
        isJumping = true;//跳跃标记激活
        if (jumptimes<2)//二段跳中跳跃次数小于2时
        {
            rb.AddForce(new Vector2(0, jumpForce));//使角色在Y轴方向有位移
            jumptimes += 1;//跳跃次数+1
            AudioCtrl.instance.JumpSound(transform.position);//播放音效
        }
        anim.SetInteger("State", 2);//动画机的值为2
        

     }
    public void KillJump()
    {
        isJumping = true;//跳跃标记激活
        if (jumptimes < 2)//二段跳中跳跃次数小于2时
        {
            rb.AddForce(new Vector2(0, jumpForce*2));//使角色在Y轴方向有位移
            jumptimes += 1;//跳跃次数+1
            AudioCtrl.instance.JumpSound(transform.position);//播放音效
        }
        anim.SetInteger("State", 2);//动画机的值为2


    }
    void Falling()
    {
        if(rb.velocity.y < 0)//当角色Y轴上的速度为负时
        {
            anim.SetInteger("State", 3);//动画机的State值为3
        }
    }
    void Fire()
    {
        if (Bullet)//当子弹开关打开时
        {
            if (sr.flipX)//如果角色已经反转
            {
                Instantiate(leftBullet, leftBulletSpawnPos.position, Quaternion.identity);//在左发射点发射子弹
            }
            else
            {
                Instantiate(rightBullet, rightBulletSpawnPos.position, Quaternion.identity);//在右发射点发射子弹
            }
            AudioCtrl.instance.FireSound(transform.position);//播放音效
        }
       

    }
    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);//消除角色的惯性
        if (!isJumping)//当角色不在跳跃状态
            anim.SetInteger("State", 0);//动画机state值为0
    }
    public void MobileMoveLeft()//当虚拟键盘收到向左信号时
    {
        leftPressed = true;//激活左按键标记
    }
    public void MobileMoveRight()//当虚拟键盘收到向右信号时
    {
        rightPressed = true;//激活右按键标记
    }
    public void MobileStop()
    {
        leftPressed = false;//消除左按键标记
        rightPressed = false;//消除右按键标记
        StopMoving();//停止移动
    }
    public void MobileMoveJump()//当虚拟键盘收到跳跃信号时
    {
        Jump();//跳跃
    }
    public void MobileMoveFire()//当虚拟键盘收到开火信号时
    {
        Fire();//发射子弹
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")|| other.gameObject.CompareTag("Box"))//当角色碰到地面或箱子时
        {
            isJumping = false;//结束跳跃状态
            jumptimes = 0;//重置二段跳次数
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameCtrl.instance.PlayerDieAnimation(gameObject);//当角色碰到敌人时，角色死亡
        }
        if (other.gameObject.CompareTag("Mushroom"))
        {
            GameCtrl.instance.PlayerDieAnimation(gameObject);//当角色碰到敌人时，角色死亡
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))//当角色碰到硬币时
        {
            SFXCtrl.instance.ShowCoinSFX(other.gameObject.transform.position);//触发特效
            Destroy(other.gameObject);//销毁硬币
            GameCtrl.instance.UpdateCoin();
            GameCtrl.instance.UpdateScore(GameCtrl.Item.coin);//更新分数
            AudioCtrl.instance.coinPickupSound(transform.position);//播放音效

        }
        if (other.gameObject.CompareTag("BigCoin"))//当角色碰到硬币时
        {
            SFXCtrl.instance.ShowCoinSFX(other.gameObject.transform.position);//触发特效
            Destroy(other.gameObject);//销毁硬币
            GameCtrl.instance.UpdateCoin();
            GameCtrl.instance.UpdateScore(GameCtrl.Item.bigcoin);//更新分数
            AudioCtrl.instance.coinPickupSound(transform.position);//播放音效

        }
        if (other.gameObject.CompareTag("Key"))//当角色碰到钥匙时
        {
            SFXCtrl.instance.ShowPowerupSFX(other.gameObject.transform.position);//触发特效
            Destroy(other.gameObject);//销毁钥匙
            Bullet = true;//子弹开关打开
            AudioCtrl.instance.keyPickupSound(transform.position);//播放音效
        }
        if (other.gameObject.CompareTag("pass"))
        {
            GameCtrl.instance.GamePass(other.gameObject);//当角色抵达终点时，触发结算面板
        }
        if (other.gameObject.CompareTag("Mushroom"))//当角色碰到蘑菇时
        {
            is_trigger = true;
            SFXCtrl.instance.ShowCoinSFX(other.gameObject.transform.position);//触发特效
            Destroy(other.gameObject);//销毁蘑菇

        }
    }
}

