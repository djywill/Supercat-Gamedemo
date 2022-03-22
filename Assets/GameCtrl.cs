using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour {
    public static GameCtrl instance;
    public GameObject player;
    public Text txt_coinCnt;
    public Text player_score;
    public Text txt_score;
    public Text txt_timer;
    public float maxTime;
    public GameObject panel_gameover;
    public GameObject panel_gamepass;
    public int coinValue;
    public int bigcoinValue;
    public int enemyValue;
    public enum Item
    {
        coin,
        enemy,
        bigcoin
    }
    float timeLeft;
    int score;
    int coinCnt = 0;
	// Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
	void Start () {
        timeLeft = maxTime;  //使剩余时间多余最大时间
        AudioCtrl.instance.bgmusicSound(transform.position); //播放背景音乐
    }
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0)
        {
            UpdateTimer();
        }
        else  //当时间用完时，游戏结束面板显示
        {
            player.SetActive(false);
            panel_gameover.SetActive(true);
        }
	}
    public void PlayerDieAnimation(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-100f, 400f));  //角色击退
        player.transform.Rotate(new Vector3(0, 0, 45));  //角色倾斜
        player.GetComponent<playerctrl>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        foreach(Collider2D col in player.GetComponents<Collider2D>())
        {
            col.enabled = false;
        }
        Camera.main.GetComponent<CameraCtrl>().enabled = false;
        StartCoroutine("PauseBeforeDie",player);  //运行角色死亡函数
    }
    IEnumerator PauseBeforeDie(GameObject player)
    {
        yield return new WaitForSeconds(2.5f);  //延迟运行
        PlayerDie(player);
    }
    public void PlayerDie(GameObject player)
    {
        player.SetActive(false);
        panel_gameover.SetActive(true);  //游戏结束面板显示
        AudioCtrl.instance.gameoverSound(transform.position);//播放音效
    }
    public void GamePass(GameObject player)
    {
        player.SetActive(false);
        panel_gamepass.SetActive(true); //通关面板显示
        AudioCtrl.instance.gameoverSound(transform.position);//播放音效
    }
    public void ReStartLevel()
    {
        SceneManager.LoadScene("DJYLevel_1");
    }
    public void UpdateCoin()
    {
        coinCnt++;
        txt_coinCnt.text = "X" + coinCnt;
    }
    /*
    public void UpdateScore(int value)
    {
        score += value;
        txt_score.text = "Score: " + score;
    }
    */
    public void UpdateScore(Item i)  //当击败怪物、吃到金币的时候，分数增加
    {
        switch (i)
        {
            case Item.coin:
                score += coinValue;
                break;
            case Item.enemy:
                score += enemyValue;
                break;
            case Item.bigcoin:
                score += bigcoinValue;
                break;
        }
        txt_score.text = "Score: " + score;
        player_score.text = "Score: " + score;
    }
    public void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        txt_timer.text = "Timer: " + (int)timeLeft;
        /*
        if (timeLeft <= 0)
        {
            PlayerDie(player);
        }
        */
    }
}
