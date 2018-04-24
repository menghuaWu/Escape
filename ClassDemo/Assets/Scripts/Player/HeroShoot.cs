using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShoot : MonoBehaviour {

    public LayerMask layerMask;

    private Camera fpsCam;
    private Animator animator;
    private int shootDamage = 2; 

    private void Awake()
    {
        fpsCam = Camera.main;
        
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Shoot", true);
            Shoot();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Shoot", false);
        }
    }

    public void Shoot()
    {
        Vector3 camRay = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0.0f));

        RaycastHit hit;

        if (Physics.Raycast(camRay, fpsCam.transform.forward, out hit, 500f, layerMask))
        {
            Debug.Log("000");
            Shotable shotable = hit.collider.GetComponent<Shotable>();
            if(shotable != null)
            {
                shotable.OnDamage(shootDamage);
            }
        }
        
        
    }
}
