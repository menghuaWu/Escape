using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public Canvas story;
    public Canvas winMessage;
    public GameObject came;
    public GameObject playerCam;
    public GameObject winScene;

    public enum State {
        DELAY,
        PLAY,
        WIN
    }

    State state;
    public bool haveKey;
    
    private void Awake()
    {
        if (Package.key)
        {
            state = State.WIN;

        }
        else
        {

            state = State.DELAY;
        }
        
        
    }

    // Use this for initialization
    void Start () {
        if (Package.key)
        {
            haveKey = true;
        }
        else
        {
            winScene.SetActive(false);
            playerCam.SetActive(true);
            came.SetActive(false);
            haveKey = false;
        }



        
        story.gameObject.SetActive(false);
        SetState(state);
    }
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public void SetState(State currState)
    {
        switch (currState)
        {
            case State.DELAY:
                DelayGame();
                break;
            case State.PLAY:
                PlayGame();
                break;
            case State.WIN:
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
    private void PlayGame()
    {

        StopCoroutine(ShowMessage());
        story.gameObject.SetActive(false);
    }
    private void WinTheGame()
    {
        came.SetActive(true);
        playerCam.SetActive(false);
        
        winScene.SetActive(true);
        //播放鑰匙開門動畫
    }


    public void OnClickToStart()
    {
       
        state = State.PLAY;
        SetState(state);
    }

    IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(1f);
        if (haveKey)
        {
            winMessage.gameObject.SetActive(true);

            story.gameObject.SetActive(false);
        }
        else
        {
            winMessage.gameObject.SetActive(false);
            story.gameObject.SetActive(true);
        }
    }

    
}
