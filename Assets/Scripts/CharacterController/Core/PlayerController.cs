using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public CharacterController cc { get; private set; }
    [field: SerializeField] public PlayerConfig playerConfig { get; private set; }
    [SerializeField] private PlayerInputManager playerInput;
    [SerializeField] private PlayerStateManager stateManager;
    private Vector3 movement;
    private float speed;
    private float verticalSpeed = 0;
    private float xMovement = 0;
    private float yMovement = 0;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);

        switch (stateManager.playerState)
        {
            case PlayerState.isOnGround:
            speed = playerConfig.walkSpeed;
            verticalSpeed = 0;
            playerInput.SetLerpSpeed(playerConfig.lerpSpeed.max);
            break;

            case PlayerState.isOnAir:
            playerInput.SetLerpSpeed(playerConfig.lerpSpeed.min);
            speed = playerConfig.airSpeed;
            verticalSpeed -= (verticalSpeed > -playerConfig.gravity) ? playerConfig.gravity * Time.deltaTime : 0;
            break;
            
            case PlayerState.isJumping:
            verticalSpeed = playerConfig.jumpSpeed;
            break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xMovement = playerInput.moveInput.x * speed;
        yMovement = playerInput.moveInput.y * speed;

        movement = transform.TransformDirection(new Vector3(xMovement,
        verticalSpeed,
        yMovement));

        cc.Move(movement * Time.fixedDeltaTime);
    }
}
