using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateIdle : IState
{
    
    public void StateEnter(StateManager cxt)
    {
        cxt.stats.SetSpeed(0f);
    }

    public void StateExit()
    { 

    }

    public void StateUpdate(StateManager cxt) 
    {
        if (cxt.input.IsWalking)
        {
            cxt.ChangeState(cxt.stateWalking);




        }
    cxt.controller.Move(cxt.movement.GetNormalMovement(
    cxt.playerForward,
    cxt.playerRight,
    cxt.stats.GetSpeed(),
    cxt.isPlayerGrounded,
    cxt.input.IsJumping,
    cxt.input.MovementInput,
    cxt.stats.GetGravity(),
    cxt.stats.GetJumpForce()));
    }
}
