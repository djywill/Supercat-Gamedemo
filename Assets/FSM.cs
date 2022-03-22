using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer sr;
    public int verx;
    public enum FSMstate {
        None,
        Patrol,
        Chase,
    }
    public FSMstate curState;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        curState = FSMstate.Patrol;
	}
	
	// Update is called once per frame
	void Update () {
        switch (curState)
        {
            case FSMstate.Patrol:
                StatePatrol();
                break;
            case FSMstate.Chase:
                StateChase();
                break;
        }
    }
    void StatePatrol(){
        Move();
        SetDirection();
        if (playerctrl.is_trigger == true)
        {
            curState = FSMstate.Chase;
        }
    }
    void StateChase(){
        rb.velocity = new Vector2(0, 5);
        Debug.Log("CHASE");
    }
    void Move()
    {
        rb.velocity = new Vector2(verx, 0);
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
    void ChangeDirection()
    {
        verx = -verx;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Box"))
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
