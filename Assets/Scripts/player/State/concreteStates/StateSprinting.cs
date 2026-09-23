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


        if (!cxt.input.InputSprinting)
        {
            cxt.ChangeState(cxt.stateWalking);
        }

        if (cxt.input.InputJumping && cxt.isPlayerGrounded)
        {
            cxt.ChangeState(cxt.stateJumping);
        }

        if (cxt.input.InputCrouching)
        {
            cxt.ChangeState(cxt.stateCrouching);
        }
    }

}
