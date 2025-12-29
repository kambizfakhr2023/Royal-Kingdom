using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI movesText;
    public TextMeshProUGUI progressText;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject[] starIcons; // size 3

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateMoves(int moves)
    {
        movesText.text = $"Moves: {moves}";
    }

    public void UpdateProgress(int current, int target)
    {
        progressText.text = $"{current}/{target}";
    }

    public void ShowWin(int stars)
    {
        winPanel.SetActive(true);

        for (int i = 0; i < starIcons.Length; i++)
            starIcons[i].SetActive(i < stars);
    }


    public void ShowLose()
    {
        losePanel.SetActive(true);
    }
}
