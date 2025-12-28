using UnityEngine;

public enum TileType
{
    Normal,
    Bomb,
    Rocket
}

public class Tile : MonoBehaviour
{
    [HideInInspector] public int x;
    [HideInInspector] public int y;

    public TileType tileType = TileType.Normal;
    public SpriteRenderer spriteRenderer;

    private Vector3 originalScale;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    public void SetPosition(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public void Select()
    {
        transform.localScale = originalScale * 1.1f;
    }

    public void Deselect()
    {
        transform.localScale = originalScale;
    }
}
