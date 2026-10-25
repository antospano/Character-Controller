using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class works best with the default InputSystem configured actions "move", "jump" and "look".
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private string _moveAction = "Move";
    [SerializeField] private string _jumpAction = "Jump";
    [SerializeField] private string _lookAction = "Look";
    public float lerpSpeed { get; private set; } = 10f;

    public InputAction moveAction { get; private set; }
    public InputAction jumpAction { get; private set; }
    public InputAction lookAction { get; private set; }

    public Vector2 _moveInput { get; private set; }
    public Vector2 moveInput { get; private set; } = Vector2.zero;
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
        _moveInput = moveAction.ReadValue<Vector2>();
        
        moveInput = Vector2.Lerp(moveInput, _moveInput, lerpSpeed * Time.deltaTime);

        lookInput = lookAction.ReadValue<Vector2>();
        isJumping = jumpAction.IsPressed();
    }

    public void SetLerpSpeed(float newValue)
    {
        this.lerpSpeed = newValue;
    }
}
