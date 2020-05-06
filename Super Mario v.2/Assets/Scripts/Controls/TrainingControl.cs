using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingControl : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackPressed()
    {
        SceneManager.LoadScene("Training");
    }
}