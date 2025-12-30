using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;

    public TextMeshProUGUI levelText;
    public GameObject lockIcon;
    public GameObject[] stars;

    public void Setup(int index, bool unlocked, int starCount)
    {
        levelIndex = index;
        levelText.text = index.ToString();

        lockIcon.SetActive(!unlocked);
        GetComponent<Button>().interactable = unlocked;

        for (int i = 0; i < stars.Length; i++)
            stars[i].SetActive(i < starCount);
    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("CurrentLevel", levelIndex);
        SceneManager.LoadScene("Gameplay");
    }
}
