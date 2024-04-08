using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty_", menuName = "SimpleRandWalkData")]

public class DungeonData : ScriptableObject
{
    public int iterations = 10, wLength = 10;
    public bool randIteration = true;
}