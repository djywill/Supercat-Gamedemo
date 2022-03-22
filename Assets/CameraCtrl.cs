using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
    public Transform player;
    public float yOffSet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(player.position.x, player.position.y+yOffSet, transform.position.z);
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
