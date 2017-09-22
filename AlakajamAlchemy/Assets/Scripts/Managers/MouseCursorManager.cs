// Date   : 23.09.2017 00:17
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public enum CursorType
{
    None,
    Default,
    Target
}

[System.Serializable]
public class MouseCursor : System.Object
{
    public CursorType type;
    public CursorMode mode;
    public Texture2D texture;
    public Vector2 hotspot;
}

public class MouseCursorManager : MonoBehaviour {

    public static MouseCursorManager main;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("CursorManager").Length == 0)
        {
            main = this;
            gameObject.tag = "CursorManager";
            SetCursorTarget();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private MouseCursor targetCursor;
    [SerializeField]
    private MouseCursor defaultCursor;

    public void SetCursorTarget()
    {
        SetCursor(targetCursor);
    }

    public void SetCursorDefault()
    {
        SetCursor(defaultCursor);
    }

    public void SetCursor(MouseCursor cursor)
    {
        Cursor.SetCursor(cursor.texture, cursor.hotspot, cursor.mode);
    }
}

