using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventTester : MonoBehaviour
{
    // [SerializeField] Texture2D cursorArrow;
    // [SerializeField] Texture2D cursorHand;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
        // Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        // Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
