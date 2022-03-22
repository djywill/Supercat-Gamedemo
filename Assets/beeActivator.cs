using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeActivator : MonoBehaviour {
    public GameObject bee;
    BeeAI beeai;
	// Use this for initialization
	void Start () {
        beeai = bee.GetComponent<BeeAI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beeai.ActiveBee();
            Debug.Log("beeative");
        }
    }
}
