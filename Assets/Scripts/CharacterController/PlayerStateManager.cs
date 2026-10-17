using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerGroundCheck groundCheck;
    public Vector2 inputOnJump { get; private set; } = Vector2.zero;
    public PlayerState playerState { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PlayerState.isJumping && !groundCheck.isGrounded)
        {
            if (playerInput.moveInput != inputOnJump) inputOnJump = Vector2.zero;
            playerState = PlayerState.isOnAir;
        }

        if (!playerInput.isJumping && groundCheck.isGrounded)
        {
            playerState = PlayerState.isOnGround;
        }

        if (playerInput.isJumping && groundCheck.isGrounded)
        {
            inputOnJump = playerInput.moveInput;
            playerState = PlayerState.isJumping;
        }
    }
}
