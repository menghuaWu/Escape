using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotable : MonoBehaviour {

    public int Health;
 
    public GameObject healthPart;
   

	// Use this for initialization
	void Start () {
        
        Health = 100;

    }
	
	// Update is called once per frame
	void Update () {
        
        
            
        
	}

    public void OnDamage(int hurt)
    {

        Health -= hurt;
        
        if (Health < 0)
        {
            Health = 0;
            
            gameObject.GetComponent<Animator>().SetBool("Die", true);
            
            StartCoroutine("CreatPart");
        }
    }

    IEnumerator CreatPart()
    {
        yield return new WaitForSeconds(1f);
        GameObject part;
        part = Instantiate(healthPart,transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        
        Destroy(part);
        ShotSceneGameManager._instance.CountZombie();
        Destroy(gameObject);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
        }
        else
            return;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
        }
        else return;
            

    }

   
}
