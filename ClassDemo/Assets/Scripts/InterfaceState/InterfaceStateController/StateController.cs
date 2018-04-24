using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController {

    IState state = null;

    public void SetState(IState state)
    {
        this.state = state;
    }

    //可以在這裡做判斷，選擇要執行該狀態下的哪個方法
    public void GetStateHavior(GameObject player, float H, float V,bool walk)
    { 
        state.StateEnter(player, H, V, walk);
    }
    public void GetDieState(GameObject player, bool die)
    {
        state.IsDie(player,die);
    }
}
