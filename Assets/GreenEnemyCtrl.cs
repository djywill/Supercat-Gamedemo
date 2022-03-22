using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyCtrl : MonoBehaviour {
    Rigidbody2D rb;
    public int verx;
    SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        SetDirection();
    }
        
    void Move()
    {
        rb.velocity = new Vector2(verx, 0);
    }
    void ChangeDirection()
    {
        verx = -verx;
    }
    void SetDirection()
    {
        if (verx < 0)
        {
            sr.flipX = false;
        }
        else if (verx > 0)
        {
            sr.flipX = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box") )
        {
            ChangeDirection();
        }
        if (other.gameObject.CompareTag("bullet"))//当怪物碰到子弹时，使怪物和子弹都消失
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
