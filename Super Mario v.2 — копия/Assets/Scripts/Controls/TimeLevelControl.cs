using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для секундомера 
/// </summary>
public class TimeLevelControl : MonoBehaviour
{
    public float timer = 0.0F;

    /// <summary>
    /// Каждую секунду увеличивается время
    /// </summary>
    private void Update()
    {
        if (timer < 99999.0F)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 50.0F)
        {
            SceneManager.LoadScene("Die");
        }
    }

    /// <summary>
    /// Вывод секундомера на экран
    /// </summary>
    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect((float) (Screen.width / 2), 10, 500, 500), timer.ToString("0.00"), myStyle);
    }
}