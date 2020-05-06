using UnityEngine;

/// <summary>
/// Класс для вывода количества очков в игре
/// </summary>
public class ScoreControl : MonoBehaviour
{
    /// <summary>
    /// Метод для вывода счета
    /// </summary>
    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect(0, 100, 500, 500), "Score:" + GameMetaData.Score, myStyle);
    }
}