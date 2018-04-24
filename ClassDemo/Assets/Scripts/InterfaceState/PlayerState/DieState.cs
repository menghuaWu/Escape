using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IState {

    public DieState(StateController stateController) : base(stateController) { }

    public override void IsDie(GameObject player, bool die)
    {
        player.GetComponent<Animator>().SetBool("Die",die);
        player.GetComponent<Animator>().SetBool("Walk", false);
        Debug.Log("Die");
        
    }
}
