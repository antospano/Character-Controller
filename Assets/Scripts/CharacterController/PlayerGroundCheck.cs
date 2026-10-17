using System;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radius = .2f;
    [field: SerializeField] public LayerMask groundLayer;
    public bool isGrounded { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundLayer);
    }
}
