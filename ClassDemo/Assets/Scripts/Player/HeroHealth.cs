using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour {

    public int Health = 100;
    public Image HPImage;
    StateController StateController;

    
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDamage(int hurt)
    {
        Health -= hurt;

        HPImage.fillAmount = (float)Health / 100;
        if (Health < 0)
        {
            Health = 0;
            HPImage.fillAmount = 0;
            ShotSceneGameManager._instance.SetGameState(ShotSceneGameManager.GameState.GAMEOVER);
        }
    }

    public int GetHP()
    {
        return Health;
    }

    
}
