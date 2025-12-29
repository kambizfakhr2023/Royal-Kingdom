using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI movesText;
    public TextMeshProUGUI progressText;

    public GameObject winPanel;
    public GameObject losePanel;

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

    public void ShowWin()
    {
        winPanel.SetActive(true);
    }

    public void ShowLose()
    {
        losePanel.SetActive(true);
    }
}
