using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateIdle : IState
{
    
    public void StateEnter()
    {

    }

    public void StateExit()
    { 

    }

    public void StateUpdate(StateManager cxt) 
    {
        if (cxt.input.InputWalking)
        {
            cxt.ChangeState(cxt.stateWalking);
        }
    }
}
