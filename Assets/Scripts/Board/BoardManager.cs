using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
    private bool isSwapping;
			

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

public void TrySwap(Tile tile, Direction dir)
{
    int targetX = tile.x;
    int targetY = tile.y;

    switch (dir)
    {
        case Direction.Up: targetY++; break;
        case Direction.Down: targetY--; break;
        case Direction.Left: targetX--; break;
        case Direction.Right: targetX++; break;
    }

    if (!IsInsideBoard(targetX, targetY))
        return;

    Tile otherTile = grid[targetX, targetY];
    StartCoroutine(SwapRoutine(tile, otherTile));
}

bool IsInsideBoard(int x, int y)
{
    return x >= 0 && x < width && y >= 0 && y < height;
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

IEnumerator SwapRoutine(Tile a, Tile b)
{
    if (isSwapping) yield break;
    isSwapping = true;

    yield return AnimateSwap(a, b);

    var matches = MatchFinder.FindMatches(grid, width, height);

    if (matches.Count > 0)
    {
        yield return DestroyMatches(matches);
    }
    else
    {
        yield return AnimateSwap(a, b); // revert
    }

    isSwapping = false;
}


IEnumerator RevertSwap(Tile a, Tile b)
{
    Vector3 posA = a.transform.position;
    Vector3 posB = b.transform.position;

    float time = 0f;
    float duration = 0.2f;

    // Swap back in grid
    grid[a.x, a.y] = b;
    grid[b.x, b.y] = a;

    int ax = a.x;
    int ay = a.y;

    a.SetPosition(b.x, b.y);
    b.SetPosition(ax, ay);

    while (time < duration)
    {
        a.transform.position = Vector3.Lerp(posA, posB, time / duration);
        b.transform.position = Vector3.Lerp(posB, posA, time / duration);
        time += Time.deltaTime;
        yield return null;
    }

    a.transform.position = posB;
    b.transform.position = posA;
}
	

IEnumerator AnimateSwap(Tile a, Tile b)
{
    Vector3 posA = a.transform.position;
    Vector3 posB = b.transform.position;

    float time = 0f;
    float duration = 0.2f;

    // Swap grid references
    grid[a.x, a.y] = b;
    grid[b.x, b.y] = a;

    int ax = a.x;
    int ay = a.y;

    a.SetPosition(b.x, b.y);
    b.SetPosition(ax, ay);

    while (time < duration)
    {
        a.transform.position = Vector3.Lerp(posA, posB, time / duration);
        b.transform.position = Vector3.Lerp(posB, posA, time / duration);
        time += Time.deltaTime;
        yield return null;
    }

    a.transform.position = posB;
    b.transform.position = posA;
}

IEnumerator DestroyMatches(List<Tile> matches)
{
    foreach (Tile t in matches)
    {
        grid[t.x, t.y] = null;
        Destroy(t.gameObject);
    }

    yield return new WaitForSeconds(0.2f);
}

}
