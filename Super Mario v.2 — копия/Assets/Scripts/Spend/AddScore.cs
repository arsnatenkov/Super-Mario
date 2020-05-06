using UnityEngine;


/// <summary>
/// Класс для работы с монетками
/// </summary>
public class AddScore : MonoBehaviour
{
    private Animator animator; //Поле для анимации монеток
    public AudioClip enterSound;

    /// <summary>
    /// Метод, который выполняется один раз при запуске программы.
    /// Запускает аниматор для монеток.
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    /// <summary>
    /// Метод, который определяет касание главного персонажа с монеткой
    /// </summary>
    /// <param name="other">Один из компонентов сцены, в данном случае мы ищем главного героя</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character)
        {
            GameMetaData.Score += 10; //Добавляет к счету 10 очков
            AudioSource.PlayClipAtPoint(enterSound, transform.position);
            Destroy(gameObject); //Удаляет монетку с поля
        }
    }
}