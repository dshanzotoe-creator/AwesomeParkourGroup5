using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateWalking : IState
{




    public void StateEnter(StateManager cxt)
    {
        cxt.stats.SetSpeed(5f);
        cxt.camera.setFoV(cxt.camera.nearFoV);
    }

    public void StateExit(StateManager cxt)
    { 

    }

    public void StateUpdate(StateManager cxt)
    {

        cxt.controller.Move(cxt.movement.GetNormalMovement(
            cxt.playerForward, 
            cxt.playerRight, 
            cxt.stats.GetSpeed(),
            cxt.isPlayerGrounded, 
            cxt.input.MovementInput,
            cxt.stats.GetGravity()));

        if (cxt.input.IsSprinting && cxt.stats.GetStamina() > 50)
        {
            cxt.ChangeState(cxt.stateSprinting);
        }

        if (cxt.input.IsJumping && cxt.isPlayerGrounded && cxt.stats.GetStamina() > 20)
        {
            cxt.ChangeState(cxt.stateJumping);
        }

        if (cxt.input.IsCrouching)
        { 
            cxt.ChangeState(cxt.stateCrouching);
        }

        cxt.stats.RegenStamina();
    }
}
