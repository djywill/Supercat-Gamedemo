using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public static bool is_trigger = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.CompareTag("Player"))
        {
            is_trigger = true;
        }
    }
}
