using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Score", menuName = "Data")]
public class ScoreManager: ScriptableObject
{
    public int score = 0;
    public float[] bestTime;
}
