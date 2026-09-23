using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;


public class StateJumping : IState
{


    float InitialJumpforce;
    float TopVelocity;
    public void StateEnter(StateManager cxt)
    {
        cxt.stats.DrainStamina(20);
        InitialJumpforce = 1f;
        TopVelocity = 1f;
    }

    public void StateExit(StateManager cxt)
    {

    }

    public void StateUpdate(StateManager cxt)
    {
        InitialJumpforce += 0.01f;

        if (InitialJumpforce <= TopVelocity)
            cxt.controller.Move(new Vector3(0, InitialJumpforce, 0));
        
        else
            cxt.ChangeState(cxt.stateWalking);
        
    }
}