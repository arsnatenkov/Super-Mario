using UnityEngine;

/// <summary>
/// Класс отвечающий за работу полоски жизни
/// </summary>
public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5];
    private Character character;

    /// <summary>
    /// Метод, который срабатывает вначале работы программа и вызова данного класса
    /// </summary>
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    /// <summary>
    /// Метод для обновления полоски жизни
    /// </summary>
    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < GameMetaData.Hearts) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}