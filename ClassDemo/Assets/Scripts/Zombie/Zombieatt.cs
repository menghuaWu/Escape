using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombieatt : MonoBehaviour {

    public int att = 1;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HeroHealth>().OnDamage(1);
        }
        else
            return;
    }


}
