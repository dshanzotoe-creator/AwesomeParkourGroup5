using UnityEngine;

public interface IState
{

    
    public  void StateEnter(StateManager cxt) { }

    public  void StateExit(StateManager cxt) { }

    public  void StateUpdate(StateManager cxt) { }
}
