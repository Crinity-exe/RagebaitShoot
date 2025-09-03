using UnityEngine;

[CreateAssetMenu(fileName = "WallData", menuName = "Scriptable Objects/WallData")]
public class WallData : ScriptableObject
{
    public float fireSpeedRate;
    public float enemySpawnRate;
    public float playerSpawnRate;
}
