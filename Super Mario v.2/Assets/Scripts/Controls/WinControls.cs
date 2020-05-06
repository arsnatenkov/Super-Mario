using UnityEngine;
 using UnityEngine.SceneManagement;
 
 /// <summary>
 /// Класс управления сценой победы
 /// </summary>
 public class WinControls : MonoBehaviour
 {
     private Character character;
 
     private void Start()
     {
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
     }
 
     /// <summary>
     /// Управление кнопкой играть еще
     /// </summary>
     public void PlayPressed()
     {
         GameMetaData.Level++;
         SceneManager.LoadScene($"Level_{GameMetaData.Level.ToString()}");
     }
 
     /// <summary>
     /// Управление возврата на главное меню
     /// </summary>
     public void MenuPressed()
     {
         SceneManager.LoadScene("Menu");
     }
 }