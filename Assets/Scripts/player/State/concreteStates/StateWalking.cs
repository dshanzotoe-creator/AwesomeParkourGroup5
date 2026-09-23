using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static StateMachine;

public class StateWalking : IState
{




    public void StateEnter(StateManager cxt)
    {
        cxt.stats.SetSpeed(5f);
    }

    public void StateExit(StateManager cxt)
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

        if (cxt.input.InputSprinting && cxt.controller.velocity != Vector3.zero)
        {
            cxt.ChangeState(cxt.stateSprinting);
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
