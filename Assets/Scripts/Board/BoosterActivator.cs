using System.Collections.Generic;
using UnityEngine;

public static class BoosterActivator
{
    public static List<Tile> Activate(Tile tile, Tile[,] grid, int w, int h)
    {
        List<Tile> affected = new List<Tile>();

        if (tile.tileType == TileType.RocketHorizontal)
        {
            for (int x = 0; x < w; x++)
                affected.Add(grid[x, tile.y]);
        }
        else if (tile.tileType == TileType.RocketVertical)
        {
            for (int y = 0; y < h; y++)
                affected.Add(grid[tile.x, y]);
        }
        else if (tile.tileType == TileType.Bomb)
        {
            for (int x = tile.x - 1; x <= tile.x + 1; x++)
                for (int y = tile.y - 1; y <= tile.y + 1; y++)
                    if (x >= 0 && y >= 0 && x < w && y < h)
                        affected.Add(grid[x, y]);
        }

        return affected;
    }
}
