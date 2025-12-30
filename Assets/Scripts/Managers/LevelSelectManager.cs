using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public LevelButton levelButtonPrefab;
    public Transform gridParent;

    public int totalLevels = 20;

    void Start()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            LevelButton btn = Instantiate(levelButtonPrefab, gridParent);

            int stars = SaveSystem.GetLevelStars(i);
            bool unlocked = i == 1 || SaveSystem.GetLevelStars(i - 1) > 0;

            btn.Setup(i, unlocked, stars);
        }
    }
}
