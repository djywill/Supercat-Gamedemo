using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatformCtrl : MonoBehaviour {
    Rigidbody2D rb;
    public float delay;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerfeet"))
        {
            Invoke("DropPlatform", delay);
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
