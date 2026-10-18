using UnityEngine;

[System.Serializable]
public struct LerpSpeed
{
    public float min;
    public float max;
}

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Range(1, 100)] public float walkSpeed;
    [Range(1, 100)] public float airSpeed;
    [Range(1, 100)] public float jumpSpeed;
    [Range(0, 100)] public float gravity;
    public LerpSpeed lerpSpeed;
}
