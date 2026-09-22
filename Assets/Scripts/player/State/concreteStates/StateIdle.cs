using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateIdle : IState
{
    public InputManager input;
    public void StateEnter()
    {

    }

    public void StateExit()
    { 

    }

    public void StateUpdate(StateManager _) 
    {
        if (input.IsWalking)
        {
            _.ChangeState(_.stateWalking);
        }
    }
}
