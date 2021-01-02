using UnityEngine;

public class CursorSprite : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        var mousePos = Input.mousePosition;
        var wantedPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        transform.position = wantedPosition;
    }
}
