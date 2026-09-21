using UnityEngine;

public class StateManager : MonoBehaviour
{
    
    private IState _currentState;


    void Start()
    {
            
    }
    

    // Update is called once per frame
    void Update()
    {
        _currentState.Update();
    }

    public void ChangeState(IState next)
    {
        _currentState.Exit();
        _currentState = next;
        _currentState.Enter();

    }
}
