using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    public Transform target;
    public float Xspeed;
    public float Yspeed;


    private float x;
    private float y;

    private Quaternion rotation;

  


    // Use this for initialization
    void Start () {

       
    }

    private void LateUpdate()
    {
        
        x += Input.GetAxis("Mouse X") * Xspeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * Yspeed * Time.deltaTime;       
        if (x>360)
        {
            x -= 360;
        }
        else if (x<0)
        {
            x += 360;
        }

        rotation = Quaternion.Euler(y, x, 0);
        target.transform.rotation = rotation;
        

        
    }
}
