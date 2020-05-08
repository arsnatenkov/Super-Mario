using UnityEngine;

/// <summary>
/// Класс для сцены Training
/// </summary>
public class TrainingControl : MonoBehaviour
{
    /// <summary>
    /// Метод для отображения курсора
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}