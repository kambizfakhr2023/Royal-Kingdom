using System.Collections.Generic;
using UnityEngine;

public class MatchFinder
{
    public static List<Tile> FindMatches(Tile[,] grid, int width, int height)
    {
        List<Tile> matches = new List<Tile>();

        // Horizontal matches
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width - 2; x++)
            {
                Tile a = grid[x, y];
                Tile b = grid[x + 1, y];
                Tile c = grid[x + 2, y];

                if (a != null && b != null && c != null &&
                    a.spriteRenderer.sprite == b.spriteRenderer.sprite &&
                    a.spriteRenderer.sprite == c.spriteRenderer.sprite)
                {
                    AddMatch(matches, a, b, c);
                }
            }
        }

        // Vertical matches
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height - 2; y++)
            {
                Tile a = grid[x, y];
                Tile b = grid[x, y + 1];
                Tile c = grid[x, y + 2];

                if (a != null && b != null && c != null &&
                    a.spriteRenderer.sprite == b.spriteRenderer.sprite &&
                    a.spriteRenderer.sprite == c.spriteRenderer.sprite)
                {
                    AddMatch(matches, a, b, c);
                }
            }
        }

        return matches;
    }

    static void AddMatch(List<Tile> list, params Tile[] tiles)
    {
        foreach (Tile t in tiles)
        {
            if (!list.Contains(t))
                list.Add(t);
        }
    }
}
