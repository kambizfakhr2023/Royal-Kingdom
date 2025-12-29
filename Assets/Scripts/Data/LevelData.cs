using UnityEngine;

[CreateAssetMenu(menuName = "Match3/Level Data")]
public class LevelData : ScriptableObject
{
    public int moves = 20;
    public int targetMatches = 30;
}
