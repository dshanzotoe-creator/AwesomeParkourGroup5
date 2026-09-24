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

        cxt.cameraScript.setFoV(cxt.cameraScript.farFoV);

        cxt.controller.Move(cxt.movement.GetNormalMovement(
        cxt.playerForward,
        cxt.playerRight,
        cxt.stats.GetSpeed(),
        cxt.isPlayerGrounded,
        cxt.input.IsJumping,
        cxt.input.MovementInput,
        cxt.stats.GetGravity(),
        cxt.stats.GetJumpForce()));

        

        if (cxt.stats.GetStamina() <= 0 || !cxt.input.IsSprinting)
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

        cxt.stats.DrainStamina(0.1f);
    }

}
