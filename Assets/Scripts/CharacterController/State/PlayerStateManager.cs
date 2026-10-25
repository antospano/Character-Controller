using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInput;
    [SerializeField] private PlayerGroundCheck groundCheck;
    public PlayerState playerState { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (!groundCheck.isGrounded)
        {
            playerState = PlayerState.isOnAir;
        }

        if (!playerInput.isJumping && groundCheck.isGrounded)
        {
            playerState = PlayerState.isOnGround;
        }

        if (playerInput.isJumping && groundCheck.isGrounded)
        {
            playerState = PlayerState.isJumping;
        }
    }
}
