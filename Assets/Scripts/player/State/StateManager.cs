using UnityEngine;

public class StateManager
{
    
    private IState _currentState;
    
    public StateIdle stateIdle = new StateIdle();
    public StateCrouching stateCrouching = new StateCrouching();
    public StateWalking stateWalking = new StateWalking();
    public StateSprinting stateSprinting = new StateSprinting();
    public StateJumping stateJumping = new StateJumping();

    void Start()
    {
            _currentState = stateIdle;
            _currentState.StateEnter(this);
    }
    

    // Update is called once per frame
    void Update()
    {
        _currentState.StateUpdate(this);
    }

    public void ChangeState(IState next)
    {
        _currentState.StateExit(this);
        _currentState = next;
        _currentState.StateEnter(this);

    }
}
