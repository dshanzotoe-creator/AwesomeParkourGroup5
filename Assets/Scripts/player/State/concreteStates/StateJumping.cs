using UnityEngine;


public class StateJumping : IState
{
    public void StateEnter(StateManager cxt)
    {
        cxt.stats.DrainStamina(20);
        
    }

    public void StateExit(StateManager cxt)
    {

    }

    public void StateUpdate(StateManager cxt)
    {

        
    }
}