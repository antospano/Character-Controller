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
    private Vector2 speed = Vector2.zero;
    private float currentSpeedZ = 0;
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
            speed = new Vector2(playerConfig.walkSpeed, playerConfig.walkSpeed);
            verticalSpeed = 0;
            break;
            case PlayerState.isOnAir:
            //currentSpeed = playerConfig.walkSpeed * playerConfig.airControl;

            speed = new Vector2(
                stateManager.inputOnJump.x != 0 ? playerConfig.walkSpeed : playerConfig.airSpeed,
                stateManager.inputOnJump.y != 0 ? playerConfig.walkSpeed : playerConfig.airSpeed
            );

            verticalSpeed -= (verticalSpeed > -playerConfig.gravity) ? playerConfig.gravity * 0.1f : 0;
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
        
        movement = new Vector3(playerInput.moveInput.x * speed.x,
        -playerConfig.gravity + verticalSpeed,
        playerInput.moveInput.y * speed.y) * Time.fixedDeltaTime;

        cc.Move(movement);
    }
}
