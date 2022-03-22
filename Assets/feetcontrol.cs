using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feetcontrol : MonoBehaviour {
    public GameObject GreenMonster;
    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SFXCtrl.instance.ShowLandSFX(this.gameObject.transform.position);
        }

        if (other.gameObject.CompareTag("Box"))
        {
            SFXCtrl.instance.ShowLandSFX(this.gameObject.transform.position);
            Destroy(other.gameObject);
        }
    }*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SFXCtrl.instance.ShowLandSFX(this.gameObject.transform.position);
        }
        if (other.gameObject.CompareTag("Enemyhead"))//当角色踩到怪物头时
        {
            GameCtrl.instance.UpdateScore(GameCtrl.Item.enemy);//增加分数
            Destroy(GreenMonster);//消灭怪物
            SFXCtrl.instance.ShowBigCoin(this.gameObject.transform.position);//生成金币
            playerctrl.instance.KillJump();//角色再跳跃一次
        }
        /*
        if (other.gameObject.CompareTag("Box"))
        {
            SFXCtrl.instance.ShowLandSFX(this.gameObject.transform.position);
            Destroy(other.gameObject);
        }*/
    }
}
