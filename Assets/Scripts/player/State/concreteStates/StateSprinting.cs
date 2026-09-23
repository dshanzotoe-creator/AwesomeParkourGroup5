using UnityEngine;

public class StateSprinting : IState
{
    
    public void StateEnter(StateManager cxt) 
    {
        cxt.stats.SetSpeed(10f);

    }

    public void StateExit(StateManager _)
    {

    }

    public void StateUpdate(StateManager cxt)
    {

    cxt.controller.Move(cxt.movement.GetMovement(
        cxt.playerForward,
        cxt.playerRight,
        cxt.stats.GetSpeed(),
        cxt.isPlayerGrounded,
        cxt.input.MovementInput,
        cxt.stats.GetGravity()));


        if (!cxt.input.IsSprinting)
        {
            cxt.ChangeState(cxt.stateWalking);
        }

        if (cxt.input.IsJumping && cxt.isPlayerGrounded)
        {
            cxt.ChangeState(cxt.stateJumping);
        }

        if (cxt.input.IsCrouching)
        {
            cxt.ChangeState(cxt.stateCrouching);
        }
    }

}
