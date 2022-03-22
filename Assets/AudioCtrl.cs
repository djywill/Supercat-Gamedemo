using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {
    public static AudioCtrl instance;
    public PlayerAudio pa;
    public bool soundOn;
    public Transform player;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //当声音开关打开时，播放对应的音乐
    public void JumpSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.playerJump,pos);
        }
    }
    public void FireSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.playerFire, pos);
        }
    }
    public void coinPickupSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.coinPickup, pos);
        }
    }
    public void enemyDieSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.enemyDie, pos);
        }
    }
    public void bgmusicSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.bgmusic, pos);
        }
    }
    public void keyPickupSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.keyPickup, pos);
        }
    }
    public void gameoverSound(Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(pa.gameover, pos);
        }
    }
}
