using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour {

    Transform Target;
    Shotable zombieHealth;
    NavMeshAgent agent;

    

    private void Awake()
    {
        
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        zombieHealth = GetComponent<Shotable>();
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

        if (zombieHealth.Health > 0 && Target.GetComponent<HeroHealth>().GetHP() !=0)
        {

            agent.SetDestination(Target.transform.position);
        }
        else
        {
            agent.enabled = false;
            enabled = false;

        }

    }
}
