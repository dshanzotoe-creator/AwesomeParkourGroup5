using UnityEngine;

public class StateManager : MonoBehaviour
{
    
    private IState _currentState;
    
    public StateIdle stateIdle = new StateIdle();
    public StateCrouching stateCrouching = new StateCrouching();
    public StateWalking stateWalking = new StateWalking();
    public StateSprinting stateSprinting = new StateSprinting();
    public StateJumping stateJumping = new StateJumping();


    public InputManager inputManager;
    private CharacterController controller;

    private Vector3 playerForward;
    private Vector3 playerRight;

    public bool isPlayerGrounded;

    private Vector2 movement;
    
    void Start()
    {

        inputManager = GetComponent<InputManager>();
        
        _currentState = stateIdle;
        _currentState.StateEnter(this);
    }
    

    // Update is called once per frame
    void Update()
    {
        GetGround();
        GetTransformRot();

        _currentState.StateUpdate(this);
        
    }

    public void ChangeState(IState next)
    {
        _currentState.StateExit(this);
        _currentState = next;
        _currentState.StateEnter(this);

    }

    private void GetTransformRot()
    {
        playerForward = transform.TransformDirection(Vector3.forward);
        playerRight = transform.TransformDirection(Vector3.right);
    }

    private void GetGround()
    {
        if (controller.isGrounded)
        {
            isPlayerGrounded = true;
        }
        else
        {
            isPlayerGrounded = false;
        }
    }
    private void 

}

