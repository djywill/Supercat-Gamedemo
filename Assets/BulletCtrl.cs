using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    public Vector2 bulletVelocity;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = bulletVelocity;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))//当子弹碰到怪物时
        {
            GameCtrl.instance.UpdateScore(GameCtrl.Item.enemy);//增加分数
            Destroy(other.gameObject);//消灭怪物
            SFXCtrl.instance.ShowBigCoin(this.gameObject.transform.position);//生成金币
            AudioCtrl.instance.enemyDieSound(transform.position);//播放音效
        }
    }
}
