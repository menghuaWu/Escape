using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControll : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (Package.key)
        {

            gameObject.GetComponent<Animation>().Play("open");
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}
