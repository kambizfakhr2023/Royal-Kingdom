using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Tile selectedTile;
    private Vector2 startTouchPos;
    private bool isDragging;

    public float dragThreshold = 0.3f;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectTile(startTouchPos);
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging && selectedTile != null)
            {
                Vector2 endTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DetectSwipeDirection(startTouchPos, endTouchPos);
            }

            DeselectTile();
            isDragging = false;
        }
    }

    void SelectTile(Vector2 worldPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            selectedTile = hit.collider.GetComponent<Tile>();

            if (selectedTile != null)
                selectedTile.Select();
        }
    }

    void DeselectTile()
    {
        if (selectedTile != null)
            selectedTile.Deselect();

        selectedTile = null;
    }

    void DetectSwipeDirection(Vector2 start, Vector2 end)
    {
        Vector2 delta = end - start;

        if (delta.magnitude < dragThreshold)
            return;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (delta.x > 0)
                Debug.Log("Swipe Right");
            else
                Debug.Log("Swipe Left");
        }
        else
        {
            if (delta.y > 0)
                Debug.Log("Swipe Up");
            else
                Debug.Log("Swipe Down");
        }
    }
}
