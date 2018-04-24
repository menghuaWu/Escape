using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShotSceneGameManager : MonoBehaviour {

    public GameObject StartMessage;
    public GameObject OverMessage;
    public GameObject WinnerMessage;


    public int count = 0;

    private int DieCount = 0;

    public static ShotSceneGameManager _instance;
    public Image fire;
    
    private GameObject player;

    private Animator ImgAni;


    public enum GameState{
        DELAY,
        PLAYER,
        GAMEOVER,
        WINNER
    }

    GameState gameState;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        gameState = GameState.DELAY;
        
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartMessage.gameObject.SetActive(false);
        SetGameState(gameState);
        fire.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<HeroHealth>().GetHP() == 0)
        {
            gameState = GameState.GAMEOVER;
        }
    }

    public void CountZombie()
    {
        DieCount ++;
        if (DieCount >= 60 && player.GetComponent<HeroHealth>().GetHP() !=0)
        {
            gameState = GameState.WINNER;
            SetGameState(gameState);
            
        }
    }

    public void SetGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.DELAY:
                DelayGame();
                break;
            case GameState.PLAYER:
                PlayTheGame();
                break;
            case GameState.GAMEOVER:
                GameOverTheGame();
                break;
            case GameState.WINNER:
                WinTheGame();
                break;
            default:
                break;
        }
    }

    private void DelayGame()
    {
        StartCoroutine(ShowMessage());
    }

    private void PlayTheGame()
    {
        StartMessage.gameObject.SetActive(false);
        
    }

    private void GameOverTheGame()
    {
        OverMessage.GetComponent<Animator>().SetBool("Fade",true);
        fire.gameObject.SetActive(false);
        //Time.timeScale = 0f;
        //停止遊戲功能 顯示失敗UI
    }

    private void WinTheGame()
    {
        WinnerMessage.GetComponent<Animator>().SetBool("Winner", true);
        //跳出通關UI
        Package.key = true;
        
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(1f);
        StartMessage.gameObject.SetActive(true);
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main");
    }

    public void OnClickToStart()
    {
        gameState = GameState.PLAYER;
        SetGameState(gameState);
    }

    public void OnClickToBackScene(String scene)
    {
        SceneManager.LoadScene(scene);
    }
}
