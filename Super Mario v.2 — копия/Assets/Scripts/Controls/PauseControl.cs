using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public float timer;
    public bool ispuse;
    public bool guipuse;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Метод, который останавливает игру 
    /// </summary>
    private void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false)
        {
            ispuse = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispuse == true)
        {
            ispuse = false;
        }

        if (ispuse == true)
        {
            timer = 0;
            guipuse = true;
        }
        else if (ispuse == false)
        {
            timer = 1F;
            guipuse = false;
        }
    }

    /// <summary>
    /// Метод, который после остановик игры выводит две кнопки:
    /// Продолжить и вернуться в меню
    /// </summary>
    public void OnGUI()
    {
        if (guipuse == true)
        {
            if (GUI.Button(new Rect((float) (Screen.width / 2) - 200, (float) (Screen.height / 2), 150F, 45F),
                "CONTINUE"))
            {
                ispuse = false;
                timer = 0;
                Cursor.visible = false;
            }

            if (GUI.Button(new Rect((float) (Screen.width / 2), (float) (Screen.height / 2), 150F, 45F),
                "RETURN TO MENU"))
            {
                ispuse = false;
                timer = 0;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}