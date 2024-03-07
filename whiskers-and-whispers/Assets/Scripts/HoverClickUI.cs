using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverClickUI : MonoBehaviour
{
    public Texture2D cursorTexture; // The texture for the new cursor
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(20, 20); // Setting the hotspot to (20, 20)

    void Update()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else
        {
            // If the left mouse button is not held down, revert to the default cursor
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
