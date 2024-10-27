using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float MaxSpeed = 200f;
    public float Acceleration = 0.5f;
    public float LaneDistance = 2.5f;
    public float DefaultSpeed = 5f;
}