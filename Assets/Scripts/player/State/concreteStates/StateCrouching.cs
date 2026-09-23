using System;
using Unity.VisualScripting;
using UnityEngine;

public class StateCrouching : IState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StateEnter(StateManager cxt)
    {
        cxt.stats.SetSpeed(2.5f);

    }

    // Update is called once per frame
    public void StateExit(StateManager _)
    {
        
    }

    public void StateUpdate(StateManager _)
    {
        
    }
}
