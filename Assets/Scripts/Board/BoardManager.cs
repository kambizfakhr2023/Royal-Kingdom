using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [Header("Board Size")]
    public int width = 9;
    public int height = 9;

    [Header("Tiles")]
    public GameObject tilePrefab;
    public Sprite[] tileSprites;

    [Header("Board Settings")]
    public float tileSpacing = 1f;

    private Tile[,] grid;

    private void Start()
    {
        grid = new Tile[width, height];
        GenerateBoard();
    }

    void GenerateBoard()
    {
        Vector2 boardOffset = GetBoardOffset();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 spawnPos = new Vector2(
                    x * tileSpacing + boardOffset.x,
                    y * tileSpacing + boardOffset.y
                );

                GameObject tileObj = Instantiate(tilePrefab, spawnPos, Quaternion.identity, transform);
                Tile tile = tileObj.GetComponent<Tile>();

                tile.SetPosition(x, y);

                // Assign random sprite
                Sprite randomSprite = tileSprites[Random.Range(0, tileSprites.Length)];
                tile.spriteRenderer.sprite = randomSprite;

                grid[x, y] = tile;
            }
        }
    }

    Vector2 GetBoardOffset()
    {
        float boardWidth = (width - 1) * tileSpacing;
        float boardHeight = (height - 1) * tileSpacing;

        return new Vector2(
            -boardWidth / 2f,
            -boardHeight / 2f
        );
    }
}
