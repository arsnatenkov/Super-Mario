using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Если у героя закончилиснмь жизни,
/// он попадает на сцену Die и там он может вернуться только в главное меню,
/// где будет проходить игру заново
/// </summary>
public class DieControls : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Метод для работы кнопки
    /// </summary>
    public void MenuPressed()
    {
        GameMetaData.Level = 1;
        SceneManager.LoadScene("Menu");
    }
}