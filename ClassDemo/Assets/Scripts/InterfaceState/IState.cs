using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState{

    protected StateController StateController = null;

    public IState(StateController StateController) {
        this.StateController = StateController;
    }
    //這裡可以有許多抽象方法
    public virtual void StateEnter(GameObject player, float H, float V, bool walk) { }
    public virtual void IsDie(GameObject player, bool die) { }
}
