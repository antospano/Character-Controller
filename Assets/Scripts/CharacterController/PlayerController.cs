using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public CharacterController cc { get; private set; }
    [field: SerializeField] public PlayerConfig playerConfig { get; private set; }
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerStateManager stateManager;
    //public PlayerState currentState { get; private set; }
    private Vector3 movement;
    private float jumpForce;
    private float currentSpeed = 0;
    private float verticalSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        switch (stateManager.playerState)
        {
            case PlayerState.isOnGround:
            currentSpeed = playerConfig.walkSpeed;
            verticalSpeed = 0;
            break;
            case PlayerState.isOnAir:
            currentSpeed = playerConfig.walkSpeed * playerConfig.airControl;
            verticalSpeed -= (verticalSpeed > -playerConfig.gravity) ? playerConfig.gravity * 0.2f : 0;
            //verticalSpeed = -playerConfig.gravity;
            break;
            case PlayerState.isJumping:
            verticalSpeed = playerConfig.jumpSpeed;
            break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        movement = new Vector3(playerInput.moveInput.x * currentSpeed,
        -playerConfig.gravity + verticalSpeed,
        playerInput.moveInput.y * currentSpeed) * Time.fixedDeltaTime;

        cc.Move(movement);
    }
}
