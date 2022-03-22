using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {
    public GameObject sfx_coin_pickup;
    public GameObject sfx_player_lands;
    public GameObject sfx_Powerup;
    public GameObject bigcoin;
    public static SFXCtrl instance;
	// Use this for initialization
	void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ShowCoinSFX(Vector3 pos)
    {
        Instantiate(sfx_coin_pickup, pos, Quaternion.identity);
    }
    public void ShowLandSFX(Vector3 pos)
    {
        Instantiate(sfx_player_lands, pos, Quaternion.identity);
    }
    public void ShowPowerupSFX(Vector3 pos)
    {
        Instantiate(sfx_Powerup, pos, Quaternion.identity);
    }
    public void ShowBigCoin(Vector3 pos)
    {
        Instantiate(bigcoin, pos, Quaternion.identity);//将硬币当作粒子，敌人消失后在敌人消失位置出现
    }
}
