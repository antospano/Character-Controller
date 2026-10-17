using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Range(1, 100)] public float walkSpeed;
    [Range(1, 100)] public float jumpSpeed;
    [Range(0, 1)] public float airControl;
    [Range(0, 100)] public float gravity;
    //[Range(0, 1)] public float floorDrag;
}
