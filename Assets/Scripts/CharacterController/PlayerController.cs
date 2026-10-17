using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public CharacterController cc { get; private set; }
    [field: SerializeField] public PlayerConfig playerConfig { get; private set; }
    [SerializeField] private PlayerInput playerInput;
    public PlayerState currentState { get; private set; }
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
        switch (currentState)
        {
            case PlayerState.isOnGround:
            currentSpeed = playerConfig.walkSpeed;
            //verticalSpeed = -playerConfig.gravity;
            break;
            case PlayerState.isOnAir:
            currentSpeed = playerConfig.walkSpeed * playerConfig.airControl;
            break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        movement = new Vector3(playerInput.moveInput.x * currentSpeed,
        -playerConfig.gravity,
        playerInput.moveInput.y * currentSpeed) * Time.fixedDeltaTime;

        cc.Move(movement);
    }
}
