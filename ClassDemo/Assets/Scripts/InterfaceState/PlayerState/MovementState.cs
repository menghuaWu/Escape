using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : IState
{
    public MovementState(StateController stateController) : base(stateController) { }

    

    public override void StateEnter(GameObject player,float H, float V, bool walk)
    {
        

        player.GetComponent<Animator>().SetFloat("Vertical", V);

        player.GetComponent<Animator>().SetFloat("Horizontal", H);

        player.GetComponent<Animator>().SetBool("Walk", walk);


        player.transform.Translate(new Vector3(H * 5f * Time.deltaTime, 0, V * 5f * Time.deltaTime));

        if (player.GetComponent<HeroHealth>().Health == 0)
        {
            StateController.SetState(new DieState(StateController));
            StateController.GetDieState(player, true);
        }
    }
}
