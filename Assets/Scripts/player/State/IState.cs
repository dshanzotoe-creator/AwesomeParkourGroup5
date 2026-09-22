using UnityEngine;

public interface IState
{

    
    public  void StateEnter(StateManager _) { }

    public  void StateExit(StateManager _) { }

    public  void StateUpdate(StateManager _) { }
}
