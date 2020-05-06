using UnityEngine;

/// <summary>
/// Класс для финишной сцены игры
/// </summary>
public class FinishControl : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Метод для кнопки, чтобы игрок вышел из игры, когда пройдет ее
    /// </summary>
    public void ExitPressed()
    {
        Application.Quit();
    }
}