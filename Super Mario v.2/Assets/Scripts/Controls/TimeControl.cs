using System;
using UnityEngine;

/// <summary>
/// Метод для вывода времени в меню
/// </summary>
public class TimeControl : MonoBehaviour
{
    private void OnGUI()
    {
        int saveNowHours = DateTime.Now.TimeOfDay.Hours;
        int saveNowMinutes = DateTime.Now.TimeOfDay.Minutes;
        int saveNowSeconds = DateTime.Now.TimeOfDay.Seconds;
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = (Screen.width * Screen.height * 50) / (1280 * 800);
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect((float) (Screen.width) - ((Screen.width * 500) / 1280) - 1, 10, (float)((Screen.width * 500) / 1280), (float)((Screen.height * 500) / 800)),
            "Time: " + $"H: {saveNowHours} M:{saveNowMinutes} S:{saveNowSeconds} ", myStyle);
    }
}
