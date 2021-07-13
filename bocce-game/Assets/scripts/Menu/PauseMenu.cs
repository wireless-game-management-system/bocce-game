using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public TextAnchor Anchor = TextAnchor.MiddleCenter;
    
    public float Width = 0.5f;
    public float Height = 0.5f;

    void OnGUI()
    {
        if (BocceGame.Paused)
            return;
        
        float width = Screen.width * Width;
        float height = Screen.height * Height;
        
        #region position
        
        float x = (Screen.width * transform.position.x);
        float y = (Screen.height * transform.position.y);
        
        switch (Anchor)
        {
            case TextAnchor.LowerLeft:
            case TextAnchor.LowerCenter:
            case TextAnchor.LowerRight:
                y = (Screen.height * transform.position.y) - height;
                break;
            case TextAnchor.MiddleLeft:
            case TextAnchor.MiddleCenter:
            case TextAnchor.MiddleRight:
                y = (Screen.height * transform.position.y) - (height / 2);
                break;
            case TextAnchor.UpperLeft:
            case TextAnchor.UpperCenter:
            case TextAnchor.UpperRight:
                y = (Screen.height * transform.position.y) + height;
                break;
        }
        
        switch (Anchor)
        {
            case TextAnchor.LowerLeft:
            case TextAnchor.MiddleLeft:
            case TextAnchor.UpperLeft:
                x = (Screen.width * transform.position.x) - width;
                break;
            case TextAnchor.LowerCenter:
            case TextAnchor.MiddleCenter:
            case TextAnchor.UpperCenter:
                x = (Screen.width * transform.position.x) - (width / 2);
                break;
            case TextAnchor.LowerRight:
            case TextAnchor.MiddleRight:
            case TextAnchor.UpperRight:
                x = (Screen.width * transform.position.x) + width;
                break;
        }
        
        #endregion
        
        GUI.Box(new Rect(x, y, width, height), "PAUSED");
    }
}
