using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public float WidthPercent = 0.5f; // proportional
    public float HeightPercent = 0.5f; // proportional

    Rect windowRect;

    void Start()
    {
        windowRect.x = (Screen.width * (1 - WidthPercent)) / 2;
        windowRect.y = (Screen.height * (1 - HeightPercent)) / 2;
        windowRect.width = Screen.width * WidthPercent;
        windowRect.height = Screen.height * HeightPercent;
        Debug.Log("Scene Manager: " + SceneManager.sceneCountInBuildSettings);
    }

    void OnGUI()
    {
        GUI.Window(0, windowRect, (windowID) => {
            #region Buttons

            float padding = 5;

            float x = padding;
            float y = 25;
            float width = windowRect.width - (padding * 2);
            float height = (windowRect.height - y - padding) / SceneManager.sceneCountInBuildSettings;

             if (GUI.Button(new Rect(x, y + (0 * height), width, height - padding), GetLevelName(1)))
                    SceneManager.LoadScene(1);

            if (GUI.Button(new Rect(x, y + (1 * height), width, height - padding), "Quit"))
                Application.Quit();

            #endregion Buttons
        }, "Menu");
    }

    private string GetLevelName(int index)
    {
        switch (index)
        {
            case 0:
                return "Menu";
            case 1:
                return "Bocci Ball";
        }
        return "???";
    }
}

