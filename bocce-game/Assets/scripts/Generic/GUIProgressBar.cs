using UnityEngine;
using System.Collections;

public class GUIProgressBar : MonoBehaviour
{
    public TextAnchor Anchor = TextAnchor.MiddleCenter;

    public float Width = 0.25f;
    const float Height = 20f;
    
    public float BarProgress = 0.5f;
    
    void OnGUI()
    {
        if (BocceGame.Paused)
            return;
        
        float width = Screen.width * Width;
        
        #region position
        
        float x = (Screen.width * transform.position.x);
        float y = (Screen.height * transform.position.y);
        
        switch (Anchor)
        {
            case TextAnchor.LowerLeft:
            case TextAnchor.LowerCenter:
            case TextAnchor.LowerRight:
                y = (Screen.height * (1 - transform.position.y)) - Height;
                break;
            case TextAnchor.MiddleLeft:
            case TextAnchor.MiddleCenter:
            case TextAnchor.MiddleRight:
                y = (Screen.height * (1 - transform.position.y)) - (Height / 2);
                break;
            case TextAnchor.UpperLeft:
            case TextAnchor.UpperCenter:
            case TextAnchor.UpperRight:
                y = (Screen.height * (1 - transform.position.y)) + Height;
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
        
        GUI.HorizontalSlider(new Rect(x, y, width, Height), BarProgress, 0.0f, 1.0f);
    }
}