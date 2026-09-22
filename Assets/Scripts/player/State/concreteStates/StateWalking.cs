using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateWalking : IState
{




    public void StateEnter(StateManager context)
    {
        
    }

    public void StateExit(StateManager context)
    { 

    }

    public void StateUpdate(StateManager context)
    {
        
        

        if (input.IsSprinting)
        {
            context.ChangeState(context.stateSprinting);
        }

        if (input.IsJumping && context.isPlayerGrounded)
        {
            context.ChangeState(context.stateJumping);
        }

        if (input.IsCrouching)
        { 
            context.ChangeState(context.stateCrouching);
        }
    }
}
