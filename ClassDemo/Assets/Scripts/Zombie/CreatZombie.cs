using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatZombie : MonoBehaviour {

    public Transform creatIcon;
    public GameObject Zombie;
    
	// Use this for initialization
	void Start () {
        StartCoroutine("Creat");
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    IEnumerator Creat()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 20; i++)
        {
            Instantiate(Zombie, creatIcon.transform.position, creatIcon.rotation);
            
            ShotSceneGameManager._instance.count ++;
            yield return new WaitForSeconds(1);
        }
    }
}
