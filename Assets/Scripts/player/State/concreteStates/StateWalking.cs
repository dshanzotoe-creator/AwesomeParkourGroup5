using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;


public class StateWalking : IState
{




    public void StateEnter(StateManager cxt)
    {
        cxt.stats.SetSpeed(8f);
       
    }

    public void StateExit(StateManager cxt)
    { 

    }

    public void StateUpdate(StateManager cxt)
    {

         cxt.cameraScript.setFoV(cxt.cameraScript.nearFoV);
        cxt.controller.Move(cxt.movement.GetNormalMovement(
            cxt.playerForward, 
            cxt.playerRight, 
            cxt.stats.GetSpeed(),
            cxt.isPlayerGrounded, 
            cxt.input.IsJumping,                    
            cxt.input.MovementInput,
            cxt.stats.GetGravity(),
            cxt.stats.GetJumpForce()));

        if (cxt.input.IsSprinting && cxt.stats.GetStamina() > 50)
        {
            cxt.ChangeState(cxt.stateSprinting);
        }

        if (cxt.input.IsJumping && cxt.isPlayerGrounded && cxt.stats.GetStamina() > 20)
        {
            cxt.ChangeState(cxt.stateJumping);
        }


        if(cxt.controller.velocity == Vector3.zero)
        {
            cxt.ChangeState(cxt.stateIdle);
        }

        if (cxt.controller.isGrounded)
        {
            cxt.stats.RegenStamina();
        }
        
    }
}
