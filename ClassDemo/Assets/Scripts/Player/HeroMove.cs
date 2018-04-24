using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMove : MonoBehaviour {

    StateController StateController;


    private string moveVertical = "Vertical";
    private string moveHorizontal = "Horizontal";
    

    private float moveV;
    private float moveH;

    bool walk;
    

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {


        StateController = new StateController();
        walk = false;
        gameObject.transform.Rotate(Vector3.zero);
    }
	
	// Update is called once per frame
	void Update () {
        moveV = Input.GetAxis(moveVertical);
        moveH = Input.GetAxis(moveHorizontal);
        if (moveV == 0 && moveH == 0)
        {
            walk = false;
        } else
            walk = true;

        StateController.SetState(new MovementState(StateController));
        StateController.GetStateHavior(gameObject, moveH, moveV, walk);
    }

   

}
