using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAI : MonoBehaviour {
    public GameObject player;
    public float beeSpeed;
    private bool isActive = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, beeSpeed * Time.deltaTime);
        }
        
	}
    public void ActiveBee()
    {
        isActive = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameCtrl.instance.PlayerDie(player);
            Debug.Log("playerenter");
        }
    }
}
