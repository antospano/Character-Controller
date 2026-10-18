using System;
using Unity.Mathematics;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerInputManager playerInput;
    [SerializeField, Range(1, 100)] private float sensitivity = 60f;
    [SerializeField] private float verticalOffset = 1.0f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    //private float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + verticalOffset, player.position.z);

        xRotation -= playerInput.lookInput.y * sensitivity * .01f;
        yRotation += playerInput.lookInput.x * sensitivity * .01f;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(new Vector3(xRotation, yRotation, 0));
    }
}
