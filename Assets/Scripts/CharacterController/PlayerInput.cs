using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class works best with the default InputSystem configured actions "move", "jump" and "look".
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string _moveAction = "Move";
    [SerializeField] private string _jumpAction = "Jump";
    [SerializeField] private string _lookAction = "Look";

    public InputAction moveAction { get; private set; }
    public InputAction jumpAction { get; private set; }
    public InputAction lookAction { get; private set; }

    public Vector2 moveInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isJumping { get; private set; } = false;

    void OnEnable()
    {
        moveAction = InputSystem.actions.FindAction(_moveAction);
        jumpAction = InputSystem.actions.FindAction(_jumpAction);
        lookAction = InputSystem.actions.FindAction(_lookAction);
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        lookInput = lookAction.ReadValue<Vector2>();
        isJumping = jumpAction.IsPressed();
    }
}
