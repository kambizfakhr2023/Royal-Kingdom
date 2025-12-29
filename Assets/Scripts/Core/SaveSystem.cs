using UnityEngine;

public static class SaveSystem
{
    public static void SaveLevelResult(int levelIndex, int stars)
    {
        string key = $"Level_{levelIndex}_Stars";
        int previousStars = PlayerPrefs.GetInt(key, 0);

        if (stars > previousStars)
            PlayerPrefs.SetInt(key, stars);

        PlayerPrefs.Save();
    }

    public static int GetLevelStars(int levelIndex)
    {
        return PlayerPrefs.GetInt($"Level_{levelIndex}_Stars", 0);
    }
}
