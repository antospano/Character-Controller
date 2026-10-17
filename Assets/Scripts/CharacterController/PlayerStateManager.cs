using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerGroundCheck groundCheck;
    public PlayerState playerState { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInput.isJumping && groundCheck.isGrounded)
        {
            playerState = PlayerState.isOnGround;
        }

        if (playerInput.isJumping && groundCheck.isGrounded)
        {
            playerState = PlayerState.isJumping;
        }

        if (playerState == PlayerState.isJumping && !groundCheck.isGrounded)
        {
            playerState = PlayerState.isOnAir;
        }
    }
}
