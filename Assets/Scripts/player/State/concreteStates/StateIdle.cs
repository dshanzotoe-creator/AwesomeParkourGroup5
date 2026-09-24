using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

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

        cxt.cameraScript.setFoV(cxt.cameraScript.nearFoV);
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
