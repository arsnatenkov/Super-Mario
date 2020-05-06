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
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect((float) (Screen.width) - 520, 10, 500, 500),
            "Time: " + $"H: {saveNowHours} M:{saveNowMinutes} S:{saveNowSeconds} ", myStyle);
    }
}