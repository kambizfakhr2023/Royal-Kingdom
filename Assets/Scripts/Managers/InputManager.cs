using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Tile selectedTile;
    private Vector2 startTouchPos;

    public float dragThreshold = 0.3f;
    private BoardManager board;

    private void Start()
    {
        board = FindObjectOfType<BoardManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectTile(startTouchPos);
        }

        if (Input.GetMouseButtonUp(0) && selectedTile != null)
        {
            Vector2 endTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DetectSwipe(startTouchPos, endTouchPos);
            DeselectTile();
        }
    }

    void SelectTile(Vector2 worldPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
        if (hit.collider == null) return;

        selectedTile = hit.collider.GetComponent<Tile>();
        if (selectedTile != null)
            selectedTile.Select();
    }

    void DeselectTile()
    {
        selectedTile?.Deselect();
        selectedTile = null;
    }

    void DetectSwipe(Vector2 start, Vector2 end)
    {
        Vector2 delta = end - start;
        if (delta.magnitude < dragThreshold) return;

        Direction dir;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            dir = delta.x > 0 ? Direction.Right : Direction.Left;
        else
            dir = delta.y > 0 ? Direction.Up : Direction.Down;

        board.TrySwap(selectedTile, dir);
    }
}
