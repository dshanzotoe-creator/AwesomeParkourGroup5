using System.Runtime.CompilerServices;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    
    public IState _currentState;
    
    public StateIdle stateIdle = new StateIdle();
    public StateCrouching stateCrouching = new StateCrouching();
    public StateWalking stateWalking = new StateWalking();
    public StateSprinting stateSprinting = new StateSprinting();
    public StateJumping stateJumping = new StateJumping();


    public InputManager input;
    public CharacterController controller;

    public CameraScript camera;

    public PlayerStats stats;

    public Vector3 playerForward;
    public Vector3 playerRight;
    [SerializeField] float velocity;
    public bool isPlayerGrounded;

    public PlayerMovement movement;

    
    
    void Awake()
    {

        input = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
        stats = GetComponent<PlayerStats>();
        camera = GetComponent<CameraScript>();
        _currentState = stateIdle;
        _currentState.StateEnter(this);
    }
    

    // Update is called once per frame
    void Update()
    {
        GetGround();
        GetTransformRot();

        _currentState.StateUpdate(this);
        velocity = stats.GetSpeed();
    }

    public void ChangeState(IState next)
    {
        _currentState.StateExit(this);
        _currentState = next;
        _currentState.StateEnter(this);
  
    }

    private void GetTransformRot()
    {
        playerForward = camera.transform.TransformDirection(Vector3.forward);
        playerRight = camera.transform.TransformDirection(Vector3.right);
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
   
    
}

