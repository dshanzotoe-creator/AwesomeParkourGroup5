using UnityEngine;

public interface IState
{

    
    public  void StateEnter(StateManager context, InputManager input, bool grounded) { }

    public  void StateExit(StateManager context, InputManager input, bool grounded) { }

    public  void StateUpdate(StateManager context, InputManager input, bool grounded) { }
}
