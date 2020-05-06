using UnityEngine;

/// <summary>
/// Класс для финишной сцены
/// </summary>
public class FinishScore : MonoBehaviour
{
    /// <summary>
    /// Метод для вывода финишных очков
    /// </summary>
    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect((float) Screen.width / 2 - 150, (float) Screen.height / 2, 500, 500),
            "Your Score:" + GameMetaData.Score, myStyle);
    }
}