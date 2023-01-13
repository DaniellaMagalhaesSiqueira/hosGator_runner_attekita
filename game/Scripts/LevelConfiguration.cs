using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName = "HosGator Runner/LevelConfiguration", order = 1)]
public class LevelConfiguration : ScriptableObject
{
    public float speed;
    public float minRangeObstaclesGenarator;
    public float maxRangeObstaclesGenarator;
    public int minScore;
}
