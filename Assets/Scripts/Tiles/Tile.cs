using UnityEngine;
using UnityEngine.UIElements;

public enum TileType
{
    Normal,
    RocketHorizontal,
    RocketVertical,
    Bomb
}

public enum TileColor
{
    Red,
    Blue,
    Green,
    Yellow,
    Purple,
    Orange,
    None
}


public class Tile : MonoBehaviour
{
    [HideInInspector] public int x;
    [HideInInspector] public int y;
    public TileType type;
    public TileColor color;

    public TileType tileType = TileType.Normal;
    public SpriteRenderer spriteRenderer;

    private Vector3 originalScale;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        originalColor = spriteRenderer.color;
    }

    public void SetPosition(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public void Select()
    {
        transform.localScale = originalScale * 1.1f;
        spriteRenderer.color = Color.white;
    }

    public void Deselect()
    {
        transform.localScale = originalScale;
        spriteRenderer.color = originalColor;
    }

    public void Init(int x, int y, TileType type, TileColor color)
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.color = color;
    }
}
