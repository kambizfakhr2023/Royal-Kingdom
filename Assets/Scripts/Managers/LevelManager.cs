using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public LevelData currentLevel;

    public int remainingMoves;
    public int matchesCollected;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        remainingMoves = currentLevel.moves;
        matchesCollected = 0;
        UIManager.Instance.UpdateMoves(remainingMoves);
    }

    public void UseMove()
    {
        remainingMoves--;
        UIManager.Instance.UpdateMoves(remainingMoves);

        if (remainingMoves <= 0)
            CheckLose();
    }

    public void AddMatches(int count)
    {
        matchesCollected += count;
        UIManager.Instance.UpdateProgress(matchesCollected, currentLevel.targetMatches);

        if (matchesCollected >= currentLevel.targetMatches)
            Win();
    }

    void Win()
    {
        int stars = CalculateStars();
        SaveSystem.SaveLevelResult(1, stars);
        UIManager.Instance.ShowWin(stars);
    }


    void CheckLose()
    {
        if (matchesCollected < currentLevel.targetMatches)
            UIManager.Instance.ShowLose();
    }

    int CalculateStars()
    {
        if (matchesCollected >= currentLevel.star3)
            return 3;
        if (matchesCollected >= currentLevel.star2)
            return 2;
        return 1;
    }

}
