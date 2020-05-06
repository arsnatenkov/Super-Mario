using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для управления меню
/// </summary>
public class MenuControls : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Метод для кнопки Play 
    /// </summary>
    public void PlayPressed()
    {
        GameMetaData.Level = 1;
        GameMetaData.Hearts = 5;
        SceneManager.LoadScene($"Level_{GameMetaData.Level.ToString()}");
    }

    /// <summary>
    /// Метод для кнопки Exit
    /// </summary>
    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}