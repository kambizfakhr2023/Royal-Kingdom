using UnityEngine;

[CreateAssetMenu(menuName = "Match3/Level Data")]
public class LevelData : ScriptableObject
{
    public int moves = 20;
    public int targetMatches = 30;

    [Header("Stars")]
    public int star1 = 30; // minimum
    public int star2 = 40;
    public int star3 = 50;
}
